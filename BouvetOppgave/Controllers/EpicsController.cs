using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BouvetOppgave.Data;
using BouvetOppgave.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace BouvetOppgave.Controllers
{
    public class EpicsController : Controller
    {
        private readonly BouvetOppgaveContext _context;

        HttpClient client = new HttpClient();
        string url = "https://localhost:7151/api/epicAPI/";

        public EpicsController(BouvetOppgaveContext context)
        {
            _context = context;
        }

        // GET: Epics
        public async Task<IActionResult> Index()
        {
            //var bouvetOppgaveContext = _context.Epic.Include(e => e.Project);
            //return View(await bouvetOppgaveContext.ToListAsync());

            return View(JsonConvert.DeserializeObject<List<Epic>>(await client.GetStringAsync(url)).ToList());
        }

        // GET: Epics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Epic == null)
            {
                return NotFound();
            }

            //var epic = await _context.Epic
            //    .Include(e => e.Project)
            //    .FirstOrDefaultAsync(m => m.EpicId == id);

            var epic = JsonConvert.DeserializeObject<Epic>(await client.GetStringAsync(url + id));

            if (epic == null)
            {
                return NotFound();
            }

            return View(epic);
        }

        // GET: Epics/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId");
            return View();
        }

        // POST: Epics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EpicId,EpicName,Description,ProjectId")] Epic epic)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(epic);
                //await _context.SaveChangesAsync();

                await client.PostAsJsonAsync<Epic>(url, epic);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", epic.ProjectId);
            return View(epic);
        }

        // GET: Epics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Epic == null)
            {
                return NotFound();
            }

            //var epic = await _context.Epic.FindAsync(id);

            var epic = JsonConvert.DeserializeObject<Epic>(await client.GetStringAsync(url + id));

            if (epic == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", epic.ProjectId);
            return View(epic);
        }

        // POST: Epics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EpicId,EpicName,Description,ProjectId")] Epic epic)
        {
            if (id != epic.EpicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(epic);
                    //await _context.SaveChangesAsync();

                    await client.PutAsJsonAsync<Epic>(url + id, epic);


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpicExists(epic.EpicId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", epic.ProjectId);
            return View(epic);
        }

        // GET: Epics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Epic == null)
            {
                return NotFound();
            }

            //var epic = await _context.Epic
            //    .Include(e => e.Project)
            //    .FirstOrDefaultAsync(m => m.EpicId == id);

            var epic = JsonConvert.DeserializeObject<Epic>(await client.GetStringAsync(url + id));


            if (epic == null)
            {
                return NotFound();
            }

            return View(epic);
        }

        // POST: Epics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Epic == null)
            {
                return Problem("Entity set 'BouvetOppgaveContext.Epic'  is null.");
            }
            //var epic = await _context.Epic.FindAsync(id);
            //if (epic != null)
            //{
            //    _context.Epic.Remove(epic);
            //}

            //await _context.SaveChangesAsync();

            await client.DeleteAsync(url + id);


            return RedirectToAction(nameof(Index));
        }

        private bool EpicExists(int id)
        {
          return (_context.Epic?.Any(e => e.EpicId == id)).GetValueOrDefault();
        }
    }
}

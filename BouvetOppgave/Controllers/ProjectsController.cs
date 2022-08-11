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
    public class ProjectsController : Controller
    {
        private readonly BouvetOppgaveContext _context;

        HttpClient client = new HttpClient();
        string url = "https://localhost:7151/api/projectsAPI/";

        public ProjectsController(BouvetOppgaveContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            //var bouvetOppgaveContext = _context.Project.Include(p => p.ProjectManager);
            //return View(await bouvetOppgaveContext.ToListAsync());

            return View(JsonConvert.DeserializeObject<List<Project>>(await client.GetStringAsync(url)).ToList());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            //var project = await _context.Project
            //    .Include(p => p.ProjectManager)
            //    .FirstOrDefaultAsync(m => m.ProjectId == id);

            var project = JsonConvert.DeserializeObject<Project>(await client.GetStringAsync(url + id));

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,Description,EmployeeId")] Project project)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(project);
                //await _context.SaveChangesAsync();

                await client.PostAsJsonAsync<Project>(url, project);

                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", project.EmployeeId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            //var project = await _context.Project.FindAsync(id);

            var project = JsonConvert.DeserializeObject<Project>(await client.GetStringAsync(url + id));

            if (project == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", project.EmployeeId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,Description,EmployeeId")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(project);
                    //await _context.SaveChangesAsync();

                    await client.PutAsJsonAsync<Project>(url + id, project);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", project.EmployeeId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            //var project = await _context.Project
            //    .Include(p => p.ProjectManager)
            //    .FirstOrDefaultAsync(m => m.ProjectId == id);

            var project = JsonConvert.DeserializeObject<Project>(await client.GetStringAsync(url + id));

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Project == null)
            {
                return Problem("Entity set 'BouvetOppgaveContext.Project'  is null.");
            }
            //var project = await _context.Project.FindAsync(id);
            //if (project != null)
            //{
            //    _context.Project.Remove(project);
            //}

            //await _context.SaveChangesAsync();

            await client.DeleteAsync(url + id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
          return (_context.Project?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}

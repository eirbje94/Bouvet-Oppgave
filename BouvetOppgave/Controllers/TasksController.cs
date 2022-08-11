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
using Task = BouvetOppgave.Models.Task;

namespace BouvetOppgave.Controllers
{
    public class TasksController : Controller
    {
        private readonly BouvetOppgaveContext _context;

        HttpClient client = new HttpClient();
        string url = "https://localhost:7151/api/tasksAPI/";

        public TasksController(BouvetOppgaveContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            //var bouvetOppgaveContext = _context.Task.Include(t => t.Epic).Include(t => t.Responsible);
            //return View(await bouvetOppgaveContext.ToListAsync());

            return View(JsonConvert.DeserializeObject<List<Task>>(await client.GetStringAsync(url)).ToList());

        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            //var task = await _context.Task
            //    .Include(t => t.Epic)
            //    .Include(t => t.Responsible)
            //    .FirstOrDefaultAsync(m => m.TaskId == id);

            var task = JsonConvert.DeserializeObject<Task>(await client.GetStringAsync(url + id));

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["EpicId"] = new SelectList(_context.Epic, "EpicId", "EpicId");
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,Description,EpicId,EmployeeId")] Task task)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(task);
                //await _context.SaveChangesAsync();

                await client.PostAsJsonAsync<Task>(url, task);


                return RedirectToAction(nameof(Index));
            }
            ViewData["EpicId"] = new SelectList(_context.Epic, "EpicId", "EpicId", task.EpicId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", task.EmployeeId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            //var task = await _context.Task.FindAsync(id);

            var task = JsonConvert.DeserializeObject<Task>(await client.GetStringAsync(url + id));

            if (task == null)
            {
                return NotFound();
            }
            ViewData["EpicId"] = new SelectList(_context.Epic, "EpicId", "EpicId", task.EpicId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", task.EmployeeId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,Description,EpicId,EmployeeId")] Task task)
        {
            if (id != task.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(task);
                    //await _context.SaveChangesAsync();

                    await client.PutAsJsonAsync<Task>(url + id, task);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.TaskId))
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
            ViewData["EpicId"] = new SelectList(_context.Epic, "EpicId", "EpicId", task.EpicId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", task.EmployeeId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            //var task = await _context.Task
            //    .Include(t => t.Epic)
            //    .Include(t => t.Responsible)
            //    .FirstOrDefaultAsync(m => m.TaskId == id);

            var task = JsonConvert.DeserializeObject<Task>(await client.GetStringAsync(url + id));


            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Task == null)
            {
                return Problem("Entity set 'BouvetOppgaveContext.Task'  is null.");
            }
            //var task = await _context.Task.FindAsync(id);
            //if (task != null)
            //{
            //    _context.Task.Remove(task);
            //}

            //await _context.SaveChangesAsync();

            await client.DeleteAsync(url + id);


            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
          return (_context.Task?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}

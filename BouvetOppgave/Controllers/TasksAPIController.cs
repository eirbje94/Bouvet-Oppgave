using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BouvetOppgave.Data;
using BouvetOppgave.Models;
using Task = BouvetOppgave.Models.Task;

namespace BouvetOppgave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksAPIController : ControllerBase
    {
        private readonly BouvetOppgaveContext _context;

        public TasksAPIController(BouvetOppgaveContext context)
        {
            _context = context;
        }

        // GET: api/TasksAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetTask()
        {
          if (_context.Task == null)
          {
              return NotFound();
          }
            return await _context.Task
                .Include(t => t.Epic)
                .Include(t => t.Responsible)
                .ToListAsync();
        }

        // GET: api/TasksAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Task>> GetTask(int id)
        {
          if (_context.Task == null)
          {
              return NotFound();
          }
            var task = await _context.Task
                .Include(t => t.Epic)
                .Include(t => t.Responsible)
                .FirstOrDefaultAsync(m => m.TaskId == id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/TasksAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Task task)
        {
            if (id != task.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TasksAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Task>> PostTask(Task task)
        {
          if (_context.Task == null)
          {
              return Problem("Entity set 'BouvetOppgaveContext.Task'  is null.");
          }
            _context.Task.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.TaskId }, task);
        }

        // DELETE: api/TasksAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (_context.Task == null)
            {
                return NotFound();
            }
            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return (_context.Task?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}

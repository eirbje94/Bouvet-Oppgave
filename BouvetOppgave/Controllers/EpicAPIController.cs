using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BouvetOppgave.Data;
using BouvetOppgave.Models;

namespace BouvetOppgave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicAPIController : ControllerBase
    {
        private readonly BouvetOppgaveContext _context;

        public EpicAPIController(BouvetOppgaveContext context)
        {
            _context = context;
        }

        // GET: api/EpicAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Epic>>> GetEpic()
        {
          if (_context.Epic == null)
          {
              return NotFound();
          }
            return await _context.Epic
                .Include(e => e.Project)
                .ToListAsync();
        }

        // GET: api/EpicAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Epic>> GetEpic(int id)
        {
          if (_context.Epic == null)
          {
              return NotFound();
          }
            var epic = await _context.Epic
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.EpicId == id);

            if (epic == null)
            {
                return NotFound();
            }

            return epic;
        }

        // PUT: api/EpicAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpic(int id, Epic epic)
        {
            if (id != epic.EpicId)
            {
                return BadRequest();
            }

            _context.Entry(epic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpicExists(id))
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

        // POST: api/EpicAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Epic>> PostEpic(Epic epic)
        {
          if (_context.Epic == null)
          {
              return Problem("Entity set 'BouvetOppgaveContext.Epic'  is null.");
          }
            _context.Epic.Add(epic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEpic", new { id = epic.EpicId }, epic);
        }

        // DELETE: api/EpicAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpic(int id)
        {
            if (_context.Epic == null)
            {
                return NotFound();
            }
            var epic = await _context.Epic.FindAsync(id);
            if (epic == null)
            {
                return NotFound();
            }

            _context.Epic.Remove(epic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpicExists(int id)
        {
            return (_context.Epic?.Any(e => e.EpicId == id)).GetValueOrDefault();
        }
    }
}

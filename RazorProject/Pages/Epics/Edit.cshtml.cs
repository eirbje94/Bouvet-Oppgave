using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorProject.Data;
using RazorProject.Models;

namespace RazorProject.Pages.Epics
{
    public class EditModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;

        public EditModel(RazorProject.Data.RazorProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Epic Epic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Epic == null)
            {
                return NotFound();
            }

            var epic =  await _context.Epic.FirstOrDefaultAsync(m => m.EpicId == id);
            if (epic == null)
            {
                return NotFound();
            }
            Epic = epic;
           ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Epic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpicExists(Epic.EpicId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EpicExists(int id)
        {
          return (_context.Epic?.Any(e => e.EpicId == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorProject.Data;
using RazorProject.Models;

namespace RazorProject.Pages.Epics
{
    public class DeleteModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;

        public DeleteModel(RazorProject.Data.RazorProjectContext context)
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

            var epic = await _context.Epic.FirstOrDefaultAsync(m => m.EpicId == id);

            if (epic == null)
            {
                return NotFound();
            }
            else 
            {
                Epic = epic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Epic == null)
            {
                return NotFound();
            }
            var epic = await _context.Epic.FindAsync(id);

            if (epic != null)
            {
                Epic = epic;
                _context.Epic.Remove(Epic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

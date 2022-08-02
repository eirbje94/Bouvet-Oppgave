using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorProject.Data;
using RazorProject.Models;
using Task = RazorProject.Models.Task;

namespace RazorProject.Pages.Tasks
{
    public class DeleteModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;

        public DeleteModel(RazorProject.Data.RazorProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Task Task { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FirstOrDefaultAsync(m => m.TaskId == id);

            if (task == null)
            {
                return NotFound();
            }
            else 
            {
                Task = task;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }
            var task = await _context.Task.FindAsync(id);

            if (task != null)
            {
                Task = task;
                _context.Task.Remove(Task);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

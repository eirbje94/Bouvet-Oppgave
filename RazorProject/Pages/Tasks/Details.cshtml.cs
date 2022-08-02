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
    public class DetailsModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;

        public DetailsModel(RazorProject.Data.RazorProjectContext context)
        {
            _context = context;
        }

      public Task Task { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task.Include(e => e.Epic).Include(r => r.Responsible).FirstOrDefaultAsync(m => m.TaskId == id);
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
    }
}

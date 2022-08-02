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
    public class IndexModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;

        public IndexModel(RazorProject.Data.RazorProjectContext context)
        {
            _context = context;
        }

        public IList<Task> Task { get;set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            if (_context.Task != null)
            {
                Task = await _context.Task
                .Include(t => t.Epic)
                .Include(r => r.Responsible)
                .ToListAsync();
            }
        }
    }
}

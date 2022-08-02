using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorProject.Data;
using RazorProject.Models;
using Task = System.Threading.Tasks.Task;

namespace RazorProject.Pages.Epics
{
    public class IndexModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;

        public IndexModel(RazorProject.Data.RazorProjectContext context)
        {
            _context = context;
        }

        public IList<Epic> Epic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Epic != null)
            {
                Epic = await _context.Epic
                .Include(e => e.Project).Include(p => p.Project).Include(t => t.Tasks).ToListAsync();
            }
        }
    }
}

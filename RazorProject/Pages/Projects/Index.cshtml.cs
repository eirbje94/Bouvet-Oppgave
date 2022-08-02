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

namespace RazorProject.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;

        public IndexModel(RazorProject.Data.RazorProjectContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Project != null)
            {
                Project = await _context.Project.Include(p => p.ProjectManager).Include(e => e.Epics).ThenInclude(t => t.Tasks).ToListAsync();
            }
        }

        public int TaskTotal(Project proj)
        {
            int total = 0;

            foreach (var item in proj.Epics)
            {
                total += item.Tasks.Count;
            }

            return total;
        }
    }
}

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

namespace RazorProject.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;

        public IndexModel(RazorProject.Data.RazorProjectContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employee != null)
            {
                Employee = await _context.Employee.Include(p => p.Projects).Include(t => t.Tasks).ToListAsync();
            }
        }

        public string CombineProjectNames(ICollection<Project> projects)
        {
            string finalString = "";

            foreach (var item in projects)
            {
                finalString += item.ProjectName + " ";
            }

            return finalString;
        }
    }
}

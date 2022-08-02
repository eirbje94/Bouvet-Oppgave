using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorProject.Data;
using RazorProject.Models;
using Task = RazorProject.Models.Task;

namespace RazorProject.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;

        public CreateModel(RazorProject.Data.RazorProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EpicId"] = new SelectList(_context.Epic, "EpicId", "EpicName");
        ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName");
        ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName");
            return Page();
        }

        [BindProperty]
        public Task Task { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Task == null || Task == null)
            {
                return Page();
            }

            _context.Task.Add(Task);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

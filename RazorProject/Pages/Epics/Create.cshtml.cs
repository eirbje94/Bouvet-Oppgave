using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorProject.Data;
using RazorProject.Models;

namespace RazorProject.Pages.Epics
{
    public class CreateModel : PageModel
    {
        private readonly RazorProject.Data.RazorProjectContext _context;
        [BindProperty]
        public List<SelectListItem> Options { get; set; }

        public CreateModel(RazorProject.Data.RazorProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //Options = _context.Project.Select(p =>
            //                            new SelectListItem
            //                            {
            //                                Value = p.ProjectId.ToString(),
            //                                Text = p.ProjectName
            //                            })
            //                            .ToList();

            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName");
            return Page();
        }

        [BindProperty]
        public Epic Epic { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Epic == null || Epic == null)
            {

                return Page();
            }

            _context.Epic.Add(Epic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

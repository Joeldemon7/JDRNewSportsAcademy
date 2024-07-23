using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewSportsAcademy.Data;
using NewSportsAcademy.Models;

namespace NewSportsAcademy.Pages.Fixtures
{
    public class CreateModel : PageModel
    {
        private readonly NewSportsAcademy.Data.SchoolContext _context;

        public CreateModel(NewSportsAcademy.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SportID"] = new SelectList(_context.Sports, "SportID", "SportID");
        ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "FirstName");
            return Page();
        }

        [BindProperty]
        public Fixture Fixture { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Fixtures == null || Fixture == null)
            {
                return Page();
            }

            _context.Fixtures.Add(Fixture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

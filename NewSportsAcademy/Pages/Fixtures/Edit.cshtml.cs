using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewSportsAcademy.Data;
using NewSportsAcademy.Models;

namespace NewSportsAcademy.Pages.Fixtures
{
    public class EditModel : PageModel
    {
        private readonly NewSportsAcademy.Data.SchoolContext _context;

        public EditModel(NewSportsAcademy.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fixture Fixture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fixtures == null)
            {
                return NotFound();
            }

            var fixture =  await _context.Fixtures.FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }
            Fixture = fixture;
           ViewData["SportID"] = new SelectList(_context.Sports, "SportID", "SportID");
           ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "FirstName");
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Fixture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixtureExists(Fixture.FixtureID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FixtureExists(int id)
        {
          return (_context.Fixtures?.Any(e => e.FixtureID == id)).GetValueOrDefault();
        }
    }
}

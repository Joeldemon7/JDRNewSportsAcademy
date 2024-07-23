using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewSportsAcademy.Data;
using NewSportsAcademy.Models;

namespace NewSportsAcademy.Pages.Fixtures
{
    public class DetailsModel : PageModel
    {
        private readonly NewSportsAcademy.Data.SchoolContext _context;

        public DetailsModel(NewSportsAcademy.Data.SchoolContext context)
        {
            _context = context;
        }

      public Fixture Fixture { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fixtures == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures.FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }
            else 
            {
                Fixture = fixture;
            }
            return Page();
        }
    }
}

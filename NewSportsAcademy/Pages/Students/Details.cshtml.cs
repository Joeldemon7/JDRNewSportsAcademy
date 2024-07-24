using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewSportsAcademy.Data;
using NewSportsAcademy.Models;

namespace NewSportsAcademy.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolContext _context;

        public DetailsModel(SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }
        public IList<Fixture> Fixtures { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(s => s.Fixtures)
                .ThenInclude(f => f.Sport)
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
            {
                return NotFound();
            }

            Fixtures = Student.Fixtures.ToList();

            return Page();
        }
    }
}


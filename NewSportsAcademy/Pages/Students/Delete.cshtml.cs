using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewSportsAcademy.Data;
using NewSportsAcademy.Models;

namespace NewSportsAcademy.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly NewSportsAcademy.Data.SchoolContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(NewSportsAcademy.Data.SchoolContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(m => m.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }

            Student = student;

            if (saveChangesError.GetValueOrDefault())
            {
                _logger.LogError("Delete failed. Try again.");
                ModelState.AddModelError(string.Empty, "Delete failed. Try again.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException)
            {
                _logger.LogError("Delete failed for student ID: {StudentID}.", student.StudentID);
                return RedirectToPage("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}

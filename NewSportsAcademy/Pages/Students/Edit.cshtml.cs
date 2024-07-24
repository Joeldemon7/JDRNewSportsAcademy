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

namespace NewSportsAcademy.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly NewSportsAcademy.Data.SchoolContext _context;

        public EditModel(NewSportsAcademy.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
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
            Student = student;
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentToUpdate = await _context.Students.FindAsync(id);
            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "student",
                s => s.FirstName, s => s.LastName, s => s.DOB, s => s.Gender, s => s.Address, s => s.ContactNumber, s => s.MedicalInformation, s => s.Email))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(studentToUpdate.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return Page();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewSportsAcademy.Data;
using NewSportsAcademy.Models;
using Microsoft.Extensions.Logging;

namespace NewSportsAcademy.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly NewSportsAcademy.Data.SchoolContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(NewSportsAcademy.Data.SchoolContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync called.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid.");
                return Page();
            }

            if (_context.Students == null || Student == null)
            {
                _logger.LogError("Context or Student is null.");
                return Page();
            }

            _context.Students.Add(Student);
            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Student created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving student.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the student.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

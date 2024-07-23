using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewSportsAcademy.Data;
using NewSportsAcademy.Models;

namespace NewSportsAcademy.Pages.Sports
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
            return Page();
        }

        [BindProperty]
        public Sport Sport { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sports == null || Sport == null)
            {
                return Page();
            }

            _context.Sports.Add(Sport);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

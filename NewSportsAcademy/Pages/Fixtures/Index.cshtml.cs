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
    public class IndexModel : PageModel
    {
        private readonly NewSportsAcademy.Data.SchoolContext _context;

        public IndexModel(NewSportsAcademy.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Fixture> Fixture { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Fixtures != null)
            {
                Fixture = await _context.Fixtures
                .Include(f => f.Sport)
                .Include(f => f.Student)
                .ToListAsync();
            }
        }
    }
}

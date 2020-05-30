using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ACWebApp.Data;
using ACWebApp.Models;

namespace ACWebApp.Pages.Owners
{
    public class DetailsModel : PageModel
    {
        private readonly ACWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(ACWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Owner Owner { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Owner = await _context.Owners.FirstOrDefaultAsync(m => m.Id == id);

            if (Owner == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ACWebApp.Data;
using ACWebApp.Models;

namespace ACWebApp.Pages.Propietarios
{
    public class DeleteModel : PageModel
    {
        private readonly ACWebApp.Data.ApplicationDbContext _context;

        public DeleteModel(ACWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propietario Propietario { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Propietario = await _context.Propietarios.FirstOrDefaultAsync(m => m.Id == id);

            if (Propietario == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Propietario = await _context.Propietarios.FindAsync(id);

            if (Propietario != null)
            {
                _context.Propietarios.Remove(Propietario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

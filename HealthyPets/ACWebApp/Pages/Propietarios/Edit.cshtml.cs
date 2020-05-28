using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACWebApp.Data;
using ACWebApp.Models;

namespace ACWebApp.Pages.Propietarios
{
    public class EditModel : PageModel
    {
        public PropietarioStore PropietarioStore { get; set; }
        public EditModel(PropietarioStore propietarioStore)
        {
            PropietarioStore = propietarioStore;
        }

        [BindProperty]
        public Propietario Propietario { get; set; }

        public void OnGet(Guid id)
        {
            Propietario = PropietarioStore.GetPropietarioById(id);
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Edit
            PropietarioStore.EditPropietario(Propietario);
            return RedirectToPage("./Index");
        }
    }
}

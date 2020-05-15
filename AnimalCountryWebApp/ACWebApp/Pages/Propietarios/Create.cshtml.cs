using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ACWebApp.Data;
using ACWebApp.Models;

namespace ACWebApp.Pages.Propietarios
{
    public class CreateModel : PageModel
    {
        public PropietarioStore PropietarioStore { get; set; }
        public CreateModel(PropietarioStore propietarioStore)
        {
            PropietarioStore = propietarioStore;
        }

        [BindProperty]
        public Propietario Propietario { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Add
            PropietarioStore.AddPropietario(Propietario);
            return RedirectToPage("./Index");
        }


        public void OnGet()
        {

        }
    }
}

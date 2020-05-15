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
    public class IndexModel : PageModel
    {
        public PropietarioStore PropietarioStore { get; set; }
        public List<Propietario> Propietarios { get; set; }

        public IndexModel(PropietarioStore propietarioStore)
        {
            PropietarioStore = propietarioStore;
            Propietarios = PropietarioStore.GetPropietarios();
        }

        public IActionResult OnPostDelete(Guid id)
        {
            PropietarioStore.DeletePropietario(id);
            return RedirectToPage();
        }

        public void OnGet()
        {
        }

    }
}

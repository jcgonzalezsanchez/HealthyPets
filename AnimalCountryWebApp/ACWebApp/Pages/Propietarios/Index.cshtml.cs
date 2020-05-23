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

        public IndexModel(PropietarioStore propietarioStore, PacienteStore pacienteStore)
        {
            PropietarioStore = propietarioStore;
            Propietarios = PropietarioStore.GetPropietarios();
        }


        //public  IActionResult Index(string searchString)
        //{
        //    var propietarios = from p in PropietarioStore.GetPropietarioById
        //                       select p;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        propietarios = propietarios.Where(x => x.PrimerNombre(searchString));
        //    }

        //    return Page(propietarios.ToList());
        //}

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

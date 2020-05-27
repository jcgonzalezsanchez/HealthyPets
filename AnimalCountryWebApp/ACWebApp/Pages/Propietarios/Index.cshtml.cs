using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ACWebApp.Data;
using ACWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ACWebApp.Pages.Propietarios
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public PropietarioStore PropietarioStore { get; set; }
        public List<Propietario> Propietarios { get; set; }
        public ApplicationUser CurrentUser { get; set; }

        public IndexModel(UserManager<ApplicationUser> userManager, PropietarioStore propietarioStore, PacienteStore pacienteStore)
        {
            PropietarioStore = propietarioStore;
            _userManager = userManager;
        }

        public IActionResult OnPostDelete(Guid id)
        {
            PropietarioStore.DeletePropietario(id);
            return RedirectToPage();
        }

        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            Propietarios = PropietarioStore.GetPropietarios(CurrentUser.CompanyId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ACWebApp.Data;
using ACWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ACWebApp.Pages.Propietarios
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUser CurrentUser { get; set; }
        public PropietarioStore PropietarioStore { get; set; }
        public CreateModel(UserManager<ApplicationUser> userManager, PropietarioStore propietarioStore)
        {
            PropietarioStore = propietarioStore;
            _userManager = userManager;
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
            //Propietario.CompanyId = CurrentUser.CompanyId;
            PropietarioStore.AddPropietario(Propietario);
            return RedirectToPage("./Index");
        }


        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
        }
    }
}

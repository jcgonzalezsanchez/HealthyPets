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

namespace ACWebApp.Pages.Owners
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUser CurrentUser { get; set; }
        public OwnerStore OwnerStore { get; set; }
        public CreateModel(UserManager<ApplicationUser> userManager, OwnerStore ownerStore)
        {
            OwnerStore = ownerStore;
            _userManager = userManager;
        }

        [BindProperty]
        public Owner Owner { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Add
            //Propietario.CompanyId = CurrentUser.CompanyId;
            OwnerStore.AddOwner(Owner);
            return RedirectToPage("./Index");
        }


        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
        }
    }
}

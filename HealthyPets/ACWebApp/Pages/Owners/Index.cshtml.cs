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

namespace ACWebApp.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public OwnerStore OwnerStore { get; set; }
        public List<Owner> Owners { get; set; }
        public ApplicationUser CurrentUser { get; set; }

        public IndexModel(UserManager<ApplicationUser> userManager, OwnerStore ownerStore, PatientStore patientStore)
        {
            OwnerStore = ownerStore;
            _userManager = userManager;

        }

        public IActionResult OnPostDelete(Guid id)
        {
            OwnerStore.DeleteOwner(id);
            return RedirectToPage();
        }

        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            Owners = OwnerStore.GetOwners(CurrentUser.CompanyId);
        }
    }
}

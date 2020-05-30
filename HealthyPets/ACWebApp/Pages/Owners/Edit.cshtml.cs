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

namespace ACWebApp.Pages.Owners
{
    public class EditModel : PageModel
    {
        public OwnerStore OwnerStore { get; set; }
        public EditModel(OwnerStore ownerStore)
        {
            OwnerStore = ownerStore;
        }

        [BindProperty]
        public Owner Owner { get; set; }

        public void OnGet(Guid id)
        {
            Owner = OwnerStore.GetOwnerById(id);
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Edit
            OwnerStore.EditOwner(Owner);
            return RedirectToPage("./Index");
        }
    }
}

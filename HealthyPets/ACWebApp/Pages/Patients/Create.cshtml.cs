using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ACWebApp.Data;
using ACWebApp.Models;

namespace ACWebApp.Pages.Patients
{
    public class CreateModel : PageModel
    {
        public PatientStore PatientStore { get; set; }
        public CreateModel(PatientStore patientStore)
        {
            PatientStore = patientStore;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Add

            Patient.OwnerId = OwnerId;
            PatientStore.AddPatient(Patient);
            return RedirectToPage("./Index");
        }

        [BindProperty]
        public Guid OwnerId { get; set; }
        public void OnGet(Guid ownerid)
        {
            OwnerId = ownerid;
        }
    }
}

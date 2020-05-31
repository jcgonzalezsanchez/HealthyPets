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

namespace ACWebApp.Pages.Patients
{
    public class EditModel : PageModel
    {
        public PatientStore PatientStore { get; set; }
        public EditModel(PatientStore patientStore)
        {
            PatientStore = patientStore;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public void OnGet(Guid id)
        {
            Patient = PatientStore.GetPatientById(id);
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Edit
            PatientStore.EditPatient(Patient);
            return RedirectToPage("./Index");
        }
    }
}

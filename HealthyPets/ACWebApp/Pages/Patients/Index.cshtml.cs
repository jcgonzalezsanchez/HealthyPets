using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ACWebApp.Data;
using ACWebApp.Models;

namespace ACWebApp.Pages.Patients
{
    public class IndexModel : PageModel
    {
        public PatientStore PatientStore { get; set; }
        public OwnerStore OwnerStore { get; set; }
        public List<Patient> Patients { get; set; }

        public IndexModel(PatientStore pacienteStore)
        {
            PatientStore = pacienteStore;
            Patients = PatientStore.GetPatient();
        }

        public IActionResult OnPostDelete(Guid id)
        {
            PatientStore.DeletePatient(id);
            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}

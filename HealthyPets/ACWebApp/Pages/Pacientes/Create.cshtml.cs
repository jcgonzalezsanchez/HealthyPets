using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ACWebApp.Data;
using ACWebApp.Models;

namespace ACWebApp.Pages.Pacientes
{
    public class CreateModel : PageModel
    {
        public PacienteStore PacienteStore { get; set; }
        public CreateModel(PacienteStore pacienteStore)
        {
            PacienteStore = pacienteStore;
        }

        [BindProperty]
        public Paciente Paciente { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Add

            Paciente.OwnerId = OwnerId;
            PacienteStore.AddPaciente(Paciente);
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

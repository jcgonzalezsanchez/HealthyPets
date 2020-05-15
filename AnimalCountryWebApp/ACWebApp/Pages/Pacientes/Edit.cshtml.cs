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

namespace ACWebApp.Pages.Pacientes
{
    public class EditModel : PageModel
    {
        public PacienteStore PacienteStore { get; set; }
        public EditModel(PacienteStore pacienteStore)
        {
            PacienteStore = pacienteStore;
        }

        [BindProperty]
        public Paciente Paciente { get; set; }

        public void OnGet(Guid id)
        {
            Paciente = PacienteStore.GetPacienteById(id);
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Edit
            PacienteStore.EditPaciente(Paciente);
            return RedirectToPage("./Index");
        }
    }
}

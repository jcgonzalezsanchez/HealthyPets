using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Models
{
    public class PropietarioPaciente
    {
        public Guid PacienteId { get; set; }
        public Guid OwnerId { get; set; }
        public Paciente Paciente { get; set; }
        public Owner Owner { get; set; }
    }
}

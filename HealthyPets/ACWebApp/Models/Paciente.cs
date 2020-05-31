using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Models
{
    public class Paciente
    {
        public Paciente()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Señas particulares")]
        public string SenasParticulares { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Zona de las señas")]
        public string Zona { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Chip")]
        public string Chip { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Número del chip")]
        public string NumeroChip { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Fecha de defunción")]
        public Nullable<DateTime> FechaDefuncion { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Motivo defunción")]
        public string MotivoDefuncion { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Observación")]
        public string Observacion { get; set; }

        public List<PropietarioPaciente> PropietarioPacientes { get; set; }
    }
}

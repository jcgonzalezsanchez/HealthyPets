using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Models
{
    public class Patient
    {
        public Patient()
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
        public string Name { get; set; }


        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Señas particulares")]
        public string ParticularSigns { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Zona de las señas")]
        public string Zone { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Chip")]
        public string Chip { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Número del chip")]
        public string ChipNumber { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Fecha de defunción")]
        public Nullable<DateTime> DeathDate { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Motivo defunción")]
        public string ReasonDate { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Observación")]
        public string Observation { get; set; }

        public List<OwnerPatient> OwnersPatients { get; set; }
    }
}

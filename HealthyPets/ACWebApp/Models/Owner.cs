using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Models
{
    public class Owner
    {
        public Owner()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El tipo de identificación es requerido.")]
        [Display(Name = "Tipo de identificación")]
        public string IdentificationType { get; set; }

        [Required(ErrorMessage = "El número de identificación es requerido.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 6)]
        [Display(Name = "Número identificación")]
        public string Identification { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 7)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Número de teléfono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El celular es requerido.")]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 10)]
        [Display(Name = "Número de celular")]
        public string MovilPhone { get; set; }

        [StringLength(30, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Observación")]
        public string Obsevation { get; set; }

        public List<OwnerPatient> OwnersPatients { get; set; }

    }
}

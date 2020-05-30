using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Models
{
    public class Company
    {
        public Company()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerido.")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 2)]
        [Display(Name = "Nombre de la empresa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Nit de la empresa es requerido.")]
        [StringLength(12, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 6)]
        [Display(Name = "Nit")]
        public string Nit { get; set; }

        [Required(ErrorMessage = "La dirección de la empresa es requerida.")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 6)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "La ciudad de la empresa es requerida.")]
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Required(ErrorMessage = "El teléfono o celular de la empresa es requerido.")]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 7)]
        [Display(Name = "Teléfono o celular")]
        public string Phone { get; set; }
    }
}

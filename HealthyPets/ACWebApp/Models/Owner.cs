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
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string IdentificationType { get; set; }
        [Required]
        public string Identification { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string MovilPhone { get; set; }

        public string Email { get; set; }
        public string Obsevation { get; set; }
        public List<PropietarioPaciente> PropietarioPacientes { get; set; }
    }
}

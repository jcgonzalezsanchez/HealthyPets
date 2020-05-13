using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Models
{
    public class Propietario
    {
        public Propietario()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        [Required]
        public string TipoIdentificacion { get; set; }
        [Required]
        public string Identificacion { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Ocupacion { get; set; }
        [Required]
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        [Required]
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Correo { get; set; }
        public string Observacion { get; set; }
        public List<PropietarioPaciente> PropietarioPacientes { get; set; }
    }
}

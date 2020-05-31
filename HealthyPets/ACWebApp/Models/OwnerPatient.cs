using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Models
{
    public class OwnerPatient
    {
        public Guid PatientId { get; set; }
        public Guid OwnerId { get; set; }
        public Patient Patient { get; set; }
        public Owner Owner { get; set; }
    }
}

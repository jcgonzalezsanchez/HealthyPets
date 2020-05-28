using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid CompanyId { get; set; }
    }
}

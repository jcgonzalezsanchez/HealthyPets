using ACWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Data
{
    public class CompanyStore
    {
        public ApplicationDbContext Context { get; set; }
        public CompanyStore(ApplicationDbContext context)
        {
            Context = context;
        }

        internal void AddCompany(Company company)
        {
            Context.Companies.Add(company);
            Context.SaveChanges();
        }


    }
}

using ACWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Data
{
    public class OwnerStore
    {
        public ApplicationDbContext Context { get; set; }
        public List<PropietarioPaciente> PropietarioPaciente { get; set; }
        public OwnerStore(ApplicationDbContext context)
        {
            Context = context;
            PropietarioPaciente = Context.PropietarioPacientes //*
                .Include(x => x.Paciente) //*
                .ToList();
        }

        internal void DeleteOwner(Guid id)
        {
            var owner = Context.Owners.FirstOrDefault(x => x.Id == id);
            this.Context.Owners.Remove(owner);
            Context.SaveChanges();
        }


        internal void AddOwner(Owner owner)
        {
            Context.Owners.Add(owner);
            Context.SaveChanges();
        }

        internal Owner GetOwnerById(Guid id)
        {
            return Context.Owners.FirstOrDefault(x => x.Id == id);
        }

        internal void EditOwner(Owner owner)
        {
            Owner CurrentOwner = GetOwnerById(owner.Id);
            CurrentOwner.Name = owner.Name;
            CurrentOwner.LastName = owner.LastName;
            CurrentOwner.IdentificationType = owner.IdentificationType;
            CurrentOwner.Identification = owner.Identification;
            CurrentOwner.City = owner.City;
            CurrentOwner.Address = owner.Address;
            CurrentOwner.Phone = owner.Phone;
            CurrentOwner.MovilPhone = owner.MovilPhone;
            CurrentOwner.Email = owner.Email;
            CurrentOwner.Obsevation = owner.Obsevation;

            Context.Owners.Update(CurrentOwner);
            Context.SaveChanges();
        }

        internal List<Owner> GetOwners(Guid companyId)
        {
            return Context.Owners
                .Where(x => x.CompanyId == companyId)
                .Include(x => x.PropietarioPacientes) //*
                .ToList();
        }
    }
}

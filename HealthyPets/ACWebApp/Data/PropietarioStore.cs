using ACWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Data
{
    public class PropietarioStore
    {
        public ApplicationDbContext Context { get; set; }
        public List<PropietarioPaciente> PropietarioPaciente { get; set; }
        public PropietarioStore(ApplicationDbContext context)
        {
            Context = context;
            PropietarioPaciente = Context.PropietarioPacientes
                .Include(x => x.Paciente)
                .ToList();
        }

        internal void DeletePropietario(Guid id)
        {
            var propietario = Context.Propietarios.FirstOrDefault(x => x.Id == id);
            this.Context.Propietarios.Remove(propietario);
            Context.SaveChanges();
        }

        internal void AddPropietario(Propietario propietario)
        {
            Context.Propietarios.Add(propietario);
            Context.SaveChanges();
        }

        internal Propietario GetPropietarioById(Guid id)
        {
            return Context.Propietarios.FirstOrDefault(x => x.Id == id);
        }

        internal void EditPropietario(Propietario propietario)
        {
            Propietario CurrentPropietario = GetPropietarioById(propietario.Id);
            CurrentPropietario.PrimerNombre = propietario.PrimerNombre;
            CurrentPropietario.PrimerApellido = propietario.PrimerApellido;
            CurrentPropietario.TipoIdentificacion = propietario.TipoIdentificacion;
            CurrentPropietario.Identificacion = propietario.Identificacion;
            CurrentPropietario.Ciudad = propietario.Ciudad;

            Context.Propietarios.Update(CurrentPropietario);
            Context.SaveChanges();
        }

        internal List<Propietario> GetPropietarios(Guid companyId)
        {
            return Context.Propietarios
                .Where(x => x.CompanyId == companyId)
                .Include(x => x.PropietarioPacientes)
                .ToList();
        }
    }
}

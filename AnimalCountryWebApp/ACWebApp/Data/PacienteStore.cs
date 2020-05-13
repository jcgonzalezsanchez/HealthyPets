using ACWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Data
{
    public class PacienteStore
    {
        public ApplicationDbContext Context { get; set; }
        public PropietarioStore PropietarioStore { get; set; }
        public List<PropietarioPaciente> PropietarioPaciente { get; set; }
        public PacienteStore(ApplicationDbContext context, PropietarioStore propietarioStore)
        {
            Context = context;
            PropietarioStore = propietarioStore;
            PropietarioPaciente = Context.PropietarioPacientes
                .Include(x => x.Propietario)
                .Include(x => x.Paciente)
                .ToList();
        }

        internal List<Paciente> GetPacientes()
        {
            return Context.Pacientes
                .Include(x => x.PropietarioPacientes)
                .ToList();
        }

        internal void DeletePaciente(Guid id)
        {
            var propietario = Context.Pacientes.FirstOrDefault(x => x.Id == id);
            Context.Pacientes.Remove(propietario);
            Context.SaveChanges();
        }

        internal Paciente GetPacienteById(Guid id)
        {
            return Context.Pacientes
                //.Include(x => x.Propietarios)
                .FirstOrDefault(x => x.Id == id);
        }

        internal void AddPaciente(Paciente paciente)
        {
            Propietario propietario = PropietarioStore.GetPropietarioById(paciente.PropietarioId);
            PropietarioPaciente pp = new PropietarioPaciente
            {
                PacienteId = paciente.Id,
                PropietarioId = propietario.Id

            };

            Context.Add(pp);//Esta línea es la que agrega la relación a la tabla intermedia.
            Context.Pacientes.Add(paciente);
            Context.SaveChanges();
        }

        internal void EditPaciente(Paciente paciente)
        {
            Paciente CurrentPaciente = GetPacienteById(paciente.Id);
            CurrentPaciente.Nombre = paciente.Nombre;
            CurrentPaciente.Color = paciente.Color;
            CurrentPaciente.SenasParticulares = paciente.SenasParticulares;
            CurrentPaciente.Zona = paciente.Zona;
            CurrentPaciente.Chip = paciente.Chip;
            CurrentPaciente.NumeroChip = paciente.NumeroChip;
            CurrentPaciente.FechaNacimiento = paciente.FechaNacimiento;
            CurrentPaciente.FechaDefuncion = paciente.FechaDefuncion;
            CurrentPaciente.MotivoDefuncion = paciente.MotivoDefuncion;
            CurrentPaciente.Observacion = paciente.Observacion;

            Context.Pacientes.Update(CurrentPaciente);
            Context.SaveChanges();
        }
    }
}

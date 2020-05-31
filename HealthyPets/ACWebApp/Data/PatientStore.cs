using ACWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebApp.Data
{
    public class PatientStore
    {
        public ApplicationDbContext Context { get; set; }
        public OwnerStore OwnerStore { get; set; }
        public List<OwnerPatient> OwnerPatient { get; set; }
        public PatientStore(ApplicationDbContext context, OwnerStore ownerStore)
        {
            Context = context;
            OwnerStore = ownerStore;
            OwnerPatient = Context.OwnersPatients
                .Include(x => x.Owner)
                .Include(x => x.Patient)
                .ToList();
        }

        internal List<Patient> GetPatient()
        {
            return Context.Patients
                .Include(x => x.OwnersPatients)
                .ToList();
        }

        internal void DeletePatient(Guid id)
        {
            var owner = Context.Patients.FirstOrDefault(x => x.Id == id);
            Context.Patients.Remove(owner);
            Context.SaveChanges();
        }

        internal Patient GetPatientById(Guid id)
        {
            return Context.Patients
                //.Include(x => x.Propietarios)
                .FirstOrDefault(x => x.Id == id);
        }

        internal void AddPatient(Patient patient)
        {
            Owner owner = OwnerStore.GetOwnerById(patient.OwnerId);
            OwnerPatient pp = new OwnerPatient
            {
                PatientId = patient.Id,
                OwnerId = owner.Id

            };

            Context.Add(pp);//Esta línea es la que agrega la relación a la tabla intermedia.
            Context.Patients.Add(patient);
            Context.SaveChanges();
        }

        internal void EditPatient(Patient patient)
        {
            Patient CurrentPatient = GetPatientById(patient.Id);
            CurrentPatient.Name = patient.Name;
            CurrentPatient.Color = patient.Color;
            CurrentPatient.ParticularSigns = patient.ParticularSigns;
            CurrentPatient.Zone = patient.Zone;
            CurrentPatient.Chip = patient.Chip;
            CurrentPatient.ChipNumber = patient.ChipNumber;
            CurrentPatient.BirthDate = patient.BirthDate;
            CurrentPatient.DeathDate = patient.DeathDate;
            CurrentPatient.ReasonDate = patient.ReasonDate;
            CurrentPatient.Observation = patient.Observation;

            Context.Patients.Update(CurrentPatient);
            Context.SaveChanges();
        }
    }
}

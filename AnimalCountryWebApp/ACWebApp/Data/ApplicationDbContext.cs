using System;
using System.Collections.Generic;
using System.Text;
using ACWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ACWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PropietarioPaciente> PropietarioPacientes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PropietarioPaciente>().HasKey(x => new { x.PacienteId, x.PropietarioId });
        }
    }
}

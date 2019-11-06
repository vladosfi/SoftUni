namespace P01_HospitalDatabase.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }
         
        public DbSet<PatientMedicament> PatientsMedicaments{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePatientEntity(modelBuilder);

            ConfigureVisitationEntity(modelBuilder);
        }

        private void ConfigurePatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>()
                .HasKey(p => p.PatientId);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne(pm => pm.Patient);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired(false);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired(false);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired(false);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(80);
        }
    }
}

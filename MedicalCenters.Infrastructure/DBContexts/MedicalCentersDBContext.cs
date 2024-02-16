using MedicalCenters.Domain.Classes;
using MedicalCenters.Domain.Classes.IntermediateEntities;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using MedicalCenters.Domain.Classes.Medicines;
using MedicalCenters.Domain.Classes.Oprerations;
using MedicalCenters.Domain.Classes.Patients;
using MedicalCenters.Domain.Classes.Shifts;
using MedicalCenters.Domain.Classes.Staffs;
using MedicalCenters.Persistence.Configurations.Entities;
using MedicalCenters.Persistence.Configurations.Entities.MedicalCenters;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Infrastructure.DBContexts
{
    public class MedicalCentersDBContext : AuditableDBContext
    {
        public MedicalCentersDBContext(DbContextOptions<MedicalCentersDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicalCenterTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalWardTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MedicineTypeConfiguration());
        }

        public DbSet<MedicalCenter> MedicalCenter { get; set; }
        public DbSet<MedicalCenterType> MedicalCenterType { get; set; }
        public DbSet<MedicalWard> MedicalWard { get; set;}
        public DbSet<MedicalWardType> MedicalWardType { get; set; }
        public DbSet<MedicalUnit> MedicalUnit { get; set; }
        public DbSet<Visit> Visit { get; set; }
        public DbSet<ShiftPlan> ShiftPlan { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Allergy> Allergy { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Nurse> Nurse { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientHistory> PatientHistory { get; set; }
        public DbSet<OperationType> OperationType { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<MedicineType> MedicineType { get; set;}
        public DbSet<Medicine> Medicine { get; set; }



        public DbSet<Allergy_MedicineType> Allergy_MedicineType { get; set; }
        public DbSet<Allergy_Patient> Allergy_Patient { get; set; }
        public DbSet<Doctor_Operation> Doctor_Operation { get; set; }
        public DbSet<Doctor_Specialty> Doctor_Specialty { get; set; }
        public DbSet<Doctor_Visit> Doctor_Visit { get; set; }
        public DbSet<Medicine_Operation> Medicine_Operation { get; set; }
        public DbSet<Medicine_PatientHistory> Medicine_PatientHistory { get; set; }

    }
}

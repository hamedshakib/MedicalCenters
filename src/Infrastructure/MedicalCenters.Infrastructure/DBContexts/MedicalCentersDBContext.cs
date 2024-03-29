﻿using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.IntermediateEntities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Domain.Entities.Oprerations;
using MedicalCenters.Domain.Entities.Patients;
using MedicalCenters.Domain.Entities.Shifts;
using MedicalCenters.Domain.Entities.Staffs;
using MedicalCenters.Persistence.Configurations.Entities.MedicalCenters;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<MedicalWard> MedicalWard { get; set; }
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
        public DbSet<MedicineType> MedicineType { get; set; }
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

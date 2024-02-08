using MedicalCenters.Domain.Classes;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using MedicalCenters.Domain.Classes.Medicines;
using MedicalCenters.Domain.Classes.Oprerations;
using MedicalCenters.Domain.Classes.Patients;
using MedicalCenters.Domain.Classes.Shifts;
using MedicalCenters.Domain.Classes.Staffs;
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedicalCentersDBContext).Assembly);
        }

        public DbSet<MedicalCenter> MedicalCenter { get; set; }
        public DbSet<MedicalCenterType> MedicalCenterType { get; set; }
        public DbSet<MedicalWard> MedicalWard { get; set;}
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

    }
}

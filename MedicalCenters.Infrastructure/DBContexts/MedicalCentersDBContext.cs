using MedicalCenters.Domain.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public DbSet<MedicalCenter> MedicalCenters { get; set; }
    }
}

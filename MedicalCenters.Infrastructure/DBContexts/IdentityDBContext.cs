using MedicalCenters.Domain.Classes;
using MedicalCenters.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.DBContexts
{
    public class IdentityDBContext : AuditableDBContext
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDBContext).Assembly);
        }

        public DbSet<MedicalCenter> MedicalCenter { get; set; }
    }
}

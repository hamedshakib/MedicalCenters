using MedicalCenters.Domain.Classes;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Infrastructure.DBContexts;
using MedicalCenters.Persistence.Configurations.Entities;
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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionGroup> PermissionGroup { get; set; }
    }
}

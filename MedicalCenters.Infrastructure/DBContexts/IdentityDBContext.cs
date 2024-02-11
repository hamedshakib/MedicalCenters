using MedicalCenters.Domain.Classes;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Infrastructure.DBContexts;
using MedicalCenters.Persistence.Configurations.Entities;
using MedicalCenters.Persistence.Configurations.Entities.Identity;
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
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionGroup> PermissionGroup { get; set; }



        public DbSet<PermissionGroup_User> PermissionGroup_User { get; set; }
        public DbSet<Permission_PermissionGroup> Permission_PermissionGroup { get; set; }
        public DbSet<Permission_User> Permission_User { get; set; }
    }
}

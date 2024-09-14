using MedicalCenters.Identity.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenters.Persistence.DBContexts
{
    public class IdentityDBContext(DbContextOptions<IdentityDBContext> options) : AuditableDBContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDBContext).Assembly, IdentityConfigurationFilter);
        }

        private static bool IdentityConfigurationFilter(Type type) =>
            type.FullName?.Contains("Configurations.Entities.Identity") ?? false;

        public DbSet<User> User { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionGroup> PermissionGroup { get; set; }



        public DbSet<PermissionGroup_User> PermissionGroup_User { get; set; }
        public DbSet<Permission_PermissionGroup> Permission_PermissionGroup { get; set; }
        public DbSet<Permission_User> Permission_User { get; set; }
    }
}

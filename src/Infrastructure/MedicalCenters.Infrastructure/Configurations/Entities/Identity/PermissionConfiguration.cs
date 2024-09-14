using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.Reflection;
using Utility.Extensions;

namespace MedicalCenters.Persistence.Configurations.Entities.Identity
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            var permissions = Enum.GetValues(typeof(PermissionEnum)).Cast<PermissionEnum>();

            builder.HasData(permissions.Select(p => new Permission { Id = (int)p, Name = nameof(p), Description = p.GetDescription(), CreatedBy = 1, DateTimeCreated = DateTime.Now }));
        }
    }
}

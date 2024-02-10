using MedicalCenters.Identity.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Configurations.Entities.Identity
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {

            builder.HasData(
                new Permission { Id = 1,Name = "AddMedicalCenter",  CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 2,Name = "EditMedicalCenter",  CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 3,Name = "DeleteMedicalCenter",  CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 4,Name = "GetMedicalCenter",  CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 5,Name = "GetAllMedicalCenter",  CreatedBy = 1, DateTimeCreated = DateTime.Now }
                //new Permission { Id = 6,Name ="",  CreatedBy = 1, DateTimeCreated = DateTime.Now },
                //new Permission { Id = 7,Name ="",  CreatedBy = 1, DateTimeCreated = DateTime.Now },
                //new Permission { Id = 8,Name ="",  CreatedBy = 1, DateTimeCreated = DateTime.Now },
                //new Permission { Id = 9,Name ="",  CreatedBy = 1, DateTimeCreated = DateTime.Now }
    );
        }
    }
}

using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Configurations.Entities.MedicalCenters
{
    internal class MedicalWardTypeConfiguration : IEntityTypeConfiguration<MedicalWardType>
    {
        public void Configure(EntityTypeBuilder<MedicalWardType> builder)
        {
            builder.HasData(
                new MedicalWardType() { Id = 1, Name = "بخش قلب", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalWardType() { Id = 2, Name = "بخش ریه", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalWardType() { Id = 3, Name = "بخش کلیه", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalWardType() { Id = 4, Name = "بخش کبد", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalWardType() { Id = 5, Name = "بخش پیوند", CreatedBy = 1, DateTimeCreated = DateTime.Now }
                );
        }
    }
}

using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using MedicalCenters.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Configurations.Entities.MedicalCenters
{
    internal class MedicalCenterTypeConfiguration : IEntityTypeConfiguration<MedicalCenterType>
    {
        public void Configure(EntityTypeBuilder<MedicalCenterType> builder)
        {
            builder.HasData(
                new MedicalCenterType { Id = 1, Name = "بیمارستان", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalCenterType { Id = 2, Name = "کلینیک پزشکی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalCenterType { Id = 3, Name = "مرکز جراحی سر پایی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalCenterType { Id = 4, Name = "مرکز زایمان ", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalCenterType { Id = 5, Name = "مرکز تصویر برداری", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalCenterType { Id = 6, Name = "مرکز دیابت", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalCenterType { Id = 7, Name = "مرکز دیالیز", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new MedicalCenterType { Id = 8, Name = "مرکز توان بخشی", CreatedBy = 1, DateTimeCreated = DateTime.Now }
                );

        }
    }
}

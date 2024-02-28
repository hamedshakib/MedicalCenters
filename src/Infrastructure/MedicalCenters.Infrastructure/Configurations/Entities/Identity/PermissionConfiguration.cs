using MedicalCenters.Identity.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCenters.Persistence.Configurations.Entities.Identity
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {

            builder.HasData(
                new Permission { Id = 1, Name = "AddMedicalCenter", Description = "افزودن مرکز درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 2, Name = "EditMedicalCenter", Description = "ویرایش مرکز درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 3, Name = "DeleteMedicalCenter", Description = "حذف مرکز درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 4, Name = "SeeMedicalCenterInfo", Description = "مشاهده اطلاعات مرکز درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 5, Name = "SeeAllMedicalCentersInfos", Description = "مشاهده اطلاعات تمامی مراکز درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },

                new Permission { Id = 6, Name = "AddMedicalWard", Description = "افزودن بخش درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 7, Name = "EditMedicalWard", Description = "ویرایش بخش درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 8, Name = "DeleteMedicalWard", Description = "حذف بخش درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 9, Name = "SeeMedicalWardInfo", Description = "مشاهده اطلاعات بخش درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 10, Name = "SeeAllMedicalCenterWardsInfos", Description = "مشاهده اطلاعات تمامی بخش های مرکز درمانی", CreatedBy = 1, DateTimeCreated = DateTime.Now },

                new Permission { Id = 11, Name = "AddMedicine", Description = "افزودن دارو", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 12, Name = "EditMedicine", Description = "ویرایش دارو", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 13, Name = "DeleteMedicine", Description = "حذف دارو", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 14, Name = "SeeMedicines", Description = "مشاهده دارو ها", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                new Permission { Id = 15, Name = "SeeAllMedicineTypeMedicinesInfos", Description = "مشاهده دارو های یک نوع", CreatedBy = 1, DateTimeCreated = DateTime.Now }
    );
        }
    }
}

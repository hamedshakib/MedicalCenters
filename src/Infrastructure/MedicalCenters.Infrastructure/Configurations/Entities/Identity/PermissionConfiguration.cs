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
            List<PermissionEnum> Permissions = new List<PermissionEnum>()
            {
                PermissionEnum.AddMedicalCenter,
                PermissionEnum.EditMedicalCenter,
                PermissionEnum.DeleteMedicalCenter,
                PermissionEnum.SeeMedicalCenterInfo,
                PermissionEnum.SeeAllMedicalCentersInfos,

                PermissionEnum.AddMedicalWard,
                PermissionEnum.EditMedicalWard,
                PermissionEnum.DeleteMedicalWard,
                PermissionEnum.SeeMedicalWardInfo,
                PermissionEnum.SeeAllMedicalCenterWardsInfos,

                PermissionEnum.AddMedicine,
                PermissionEnum.EditMedicine,
                PermissionEnum.DeleteMedicine,
                PermissionEnum.SeeMedicines,
                PermissionEnum.SeeAllMedicineTypeMedicinesInfos,

            };

            builder.HasData(Permissions.Select(p => new Permission { Id = (int)p, Name = nameof(p), Description = p.GetDescription(), CreatedBy = 1, DateTimeCreated = DateTime.Now }));
        }
    }
}

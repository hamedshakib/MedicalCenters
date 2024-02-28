using MedicalCenters.Domain.Entities.Medicines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCenters.Persistence.Configurations.Entities.MedicalCenters
{
    internal class MedicineTypeConfiguration : IEntityTypeConfiguration<MedicineType>
    {
        public void Configure(EntityTypeBuilder<MedicineType> builder)
        {
            builder.HasData(
                        new MedicineType() { Id = 1, Name = "استامینوفن", Description = "", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                        new MedicineType() { Id = 2, Name = "پنی سیلین", Description = "", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                        new MedicineType() { Id = 3, Name = "دیفن هیدرامین", Description = "", CreatedBy = 1, DateTimeCreated = DateTime.Now },
                        new MedicineType() { Id = 4, Name = "فاموتیدین", Description = "", CreatedBy = 1, DateTimeCreated = DateTime.Now }
                        );
        }
    }
}

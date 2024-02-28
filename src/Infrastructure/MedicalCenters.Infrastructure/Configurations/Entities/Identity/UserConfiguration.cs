using MedicalCenters.Identity.Classes;
using MedicalCenters.Identity.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCenters.Persistence.Configurations.Entities
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            int HashAlgorithmType = 0, PeaperType = 0;
            var hasher = new PasswordHasher(HashAlgorithmType, PeaperType);
            var salt = hasher.GenerateNewSalt();

            builder.HasData(
                new User { Id = 1, UserName = "Administrator", Name = "ادمین", HashAlgorithmType = HashAlgorithmType, PeaperType = PeaperType, Salt = salt, HashedPassword = hasher.Hash("(/1f4OjRbRi6no!QDdnN*v:nyA5rnq", salt), CreatedBy = 1, DateTimeCreated = DateTime.Now }
                );

        }
    }
}

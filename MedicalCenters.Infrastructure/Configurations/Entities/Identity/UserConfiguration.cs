using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using MedicalCenters.Identity.Classes;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Infrastructure.DBContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Identity.Classes;

namespace MedicalCenters.Persistence.Configurations.Entities
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            int HashAlgorithmType = 0, PeaperType = 0;
            var hasher = new PasswordHasher(HashAlgorithmType, PeaperType);
            var salt=hasher.GenerateNewSalt();

            builder.HasData(
                new User { Id = 1, UserName = "Administrator", Name = "ادمین" , HashAlgorithmType = HashAlgorithmType, PeaperType= PeaperType, Salt = salt,HashedPassword = hasher.Hash("(/1f4OjRbRi6no!QDdnN*v:nyA5rnq", salt), CreatedBy = 1, DateTimeCreated = DateTime.Now }
                );
                
        }
    }
}

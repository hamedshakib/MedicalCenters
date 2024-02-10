using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Configurations.Entities
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, UserName = "Administrator", Name = "ادمین" , HashAlgorithmType=0,PeaperType=0,Salt = Encoding.ASCII.GetBytes(""),HashedPassword = Encoding.ASCII.GetBytes(""), CreatedBy = 1, DateTimeCreated = DateTime.Now }
                );
                
        }
    }
}

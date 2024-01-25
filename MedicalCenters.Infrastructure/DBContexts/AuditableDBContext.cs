using MedicalCenters.Domain.Classes.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Infrastructure.DBContexts
{
    public class AuditableDBContext : DbContext
    {
        public AuditableDBContext(DbContextOptions options) : base(options)
        {
        }
        public async Task<int> SaveChangesAsync(long UserId=1) 
        {
            foreach(var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                        .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                if(entry.Entity is BaseCreateableDomainEntity creatableEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        creatableEntity.CreatedBy = UserId;
                        creatableEntity.DateTimeCreated = DateTime.Now;
                    }

                    if(creatableEntity is BaseModifiableDomainEntity modifiableEntity)
                    {
                        modifiableEntity.ModifiedBy = UserId;
                        modifiableEntity.DateTimeModified = DateTime.Now;
                    }
                }
            }

            var result= await base.SaveChangesAsync();
            return result;
        }
    }
}

using MedicalCenters.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenters.Persistence.DBContexts
{
    public class AuditableDBContext : DbContext
    {
        public AuditableDBContext(DbContextOptions options) : base(options)
        {
        }
        public async Task<int> SaveChangesAsync(long userId = 1)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                        .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                if (entry.Entity is BaseCreatableDomainEntity creatableEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        creatableEntity.CreatedBy = userId;
                        creatableEntity.CreatedAt = DateTime.Now;
                    }

                    if (creatableEntity is BaseModifiableDomainEntity modifiableEntity)
                    {
                        modifiableEntity.ModifiedBy = userId;
                        modifiableEntity.ModifiedAt = DateTime.Now;
                    }
                }
            }

            var result = await base.SaveChangesAsync();
            return result;
        }
    }
}

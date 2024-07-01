using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class BaseUser : BaseCreateableDomainEntity
    {
        [Required, MaxLength(100)]
        public string UserName { get; set; }
    }
}

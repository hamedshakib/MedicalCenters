using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class BaseUser : BaseCreateableDomainEntity
    {
        [Required, StringLength(100)]
        public string UserName { get; set; }
    }
}

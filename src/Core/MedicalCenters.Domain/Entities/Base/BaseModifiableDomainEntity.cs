namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class BaseModifiableDomainEntity : BaseCreatableDomainEntity
    {
        public DateTime? ModifiedAt { get; set; }
        public long ModifiedBy { get; set; }
    }
}

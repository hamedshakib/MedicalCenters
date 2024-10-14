namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class BaseCreatableDomainEntity : BaseDomainEntity
    {
        public DateTime? CreatedAt { get; set; }
        public long CreatedBy { get; set; }
    }
}

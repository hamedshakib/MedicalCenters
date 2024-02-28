namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class BaseCreateableDomainEntity : BaseDomainEntity
    {
        public DateTime? DateTimeCreated { get; set; }
        public long CreatedBy { get; set; }
    }
}

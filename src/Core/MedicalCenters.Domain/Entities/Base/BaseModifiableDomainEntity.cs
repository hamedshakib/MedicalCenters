namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class BaseModifiableDomainEntity : BaseCreateableDomainEntity
    {
        public DateTime? DateTimeModified { get; set; }
        public long ModifiedBy { get; set; }
    }
}

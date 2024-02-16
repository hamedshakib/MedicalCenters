using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class BaseModifiableDomainEntity : BaseCreateableDomainEntity
    {
        public DateTime? DateTimeModified { get; set; }
        public long ModifiedBy { get; set; }
    }
}

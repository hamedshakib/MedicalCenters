using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Oprerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    [Table("MedicalUnit")]
    public class MedicalUnit : BaseModifiableDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Operation>? PossibleOperations { get; set; }
    }
}

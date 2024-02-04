using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    [Table("MedicalWard")]
    public class MedicalWard : BaseModifiableDomainEntity
    {
        public string Name { get; set; }
        public MedicalWardType Type { get; set; }
        public string Description { get; set; }
        public IList<MedicalUnit> Units { get; set; }
    }
}

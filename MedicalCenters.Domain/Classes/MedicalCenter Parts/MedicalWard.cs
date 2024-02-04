using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    [Table("MedicalWard")]
    public class MedicalWard : BaseModifiableDomainEntity
    {
        [Required, StringLength(70)]
        public string Name { get; set; }
        public MedicalWardType Type { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public IList<MedicalUnit> Units { get; set; }
    }
}

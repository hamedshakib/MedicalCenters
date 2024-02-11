using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Staffs
{
    [Table("Nurse")]
    public class Nurse : Personel
    {
        [Key]
        public long Id { get; set; }
    }
}

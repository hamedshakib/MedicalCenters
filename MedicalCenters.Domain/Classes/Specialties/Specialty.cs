using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Specialties
{
    [Table("Specialty")]
    public class Specialty : BaseCreateableDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SpecialtyGroup Group { get; set; }



        public IList<Doctor> Doctors { get; set; }
    }
}

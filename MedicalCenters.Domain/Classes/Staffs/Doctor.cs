using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Classes.Staffs
{
    [Table("Doctor")]
    public class Doctor : Personel
    {
        public IList<Specialty> Specialties { get; set; }
    }
}

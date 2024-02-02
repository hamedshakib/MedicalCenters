using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Staffs
{
    public class Doctor : Personel
    {
        public IList<Specialty> Specialtys { get; set; }
    }
}

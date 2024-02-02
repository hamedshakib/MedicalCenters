using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Classes.Base;

namespace MedicalCenters.Domain.Classes.Patients
{
    public class Patient : Person
    {
        public IList<Allergy>? Allergies { get; set; }
    }
}

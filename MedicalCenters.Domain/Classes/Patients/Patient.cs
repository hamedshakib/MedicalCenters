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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public IList<Allergy>? Allergies { get; set; }
    }
}

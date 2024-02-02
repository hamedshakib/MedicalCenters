using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Medicines
{
    public class MedicineType : BaseCreateableDomainEntity
    {
        public string TypeName {  get; set; }
        public string TypeDescription { get; set; }
    }
}

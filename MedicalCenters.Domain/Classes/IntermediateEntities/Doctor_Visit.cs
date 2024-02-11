using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Specialties;
using MedicalCenters.Domain.Classes.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.IntermediateEntities
{
    public class Doctor_Visit : BaseCreateableDomainEntity
    {
        [Required]
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public long VisitId { get; set; }
        public Visit Visit { get; set; }
    }
}

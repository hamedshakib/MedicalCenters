using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Specialties;
using MedicalCenters.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities.IntermediateEntities
{
    [PrimaryKey(nameof(DoctorId), nameof(VisitId))]
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

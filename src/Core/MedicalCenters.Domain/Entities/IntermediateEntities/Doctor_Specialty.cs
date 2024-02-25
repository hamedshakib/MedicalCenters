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
    [PrimaryKey(nameof(DoctorId), nameof(SpecialtyId))]
    public class Doctor_Specialty : BaseCreateableDomainEntity
    {
        [Required]
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
    }
}

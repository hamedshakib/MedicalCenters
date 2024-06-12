using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Persons.Staffs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Domain.Entities.IntermediateEntities
{
    [PrimaryKey(nameof(DoctorId), nameof(VisitId))]
    public class Doctor_Visit : BaseCreateableDomainEntity
    {
        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public long VisitId { get; set; }
        public Visit Visit { get; set; }
    }
}

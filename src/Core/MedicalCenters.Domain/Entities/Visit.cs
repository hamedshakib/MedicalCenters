using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Patients;
using MedicalCenters.Domain.Entities.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities
{
    [Table("Visit")]
    public class Visit : BaseModifiableDomainEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateTime { get; set; }
        public long? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
    }
}

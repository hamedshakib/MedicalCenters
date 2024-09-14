using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities
{
    [Table(nameof(Reservation))]
    public class Reservation : BaseModifiableDomainEntity
    {
        public new const string EntityTitle = "نوبت";

        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime ReservationAt { get; set; }
        [Required]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}

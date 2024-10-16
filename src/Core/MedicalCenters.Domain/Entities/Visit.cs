﻿using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities
{
    [Table(nameof(Visit))]
    public class Visit : BaseModifiableDomainEntity
    {
        public new const string EntityTitle = "ویزیت";

        [Key]
        public long Id { get; set; }
        [Required]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime VisitAt { get; set; }
        public long? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
    }
}

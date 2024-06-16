﻿using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Specialties
{
    [Table(nameof(Specialty))]
    public class Specialty : BaseCreateableDomainEntity
    {
        public const string EntityTitle = "تخصص";

        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public int SpecialtyGroupId { get; set; }
        public SpecialtyGroup SpecialtyGroup { get; set; }


    }
}

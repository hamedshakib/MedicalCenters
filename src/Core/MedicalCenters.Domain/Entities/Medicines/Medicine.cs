﻿using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Medicines
{
    [Table("Medicine")]
    public class Medicine : BaseModifiableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required]
        public int TypeId { get; set; }
        public MedicineType Type { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCenters.Domain.Entities.Base;

namespace MedicalCenters.Domain.Entities.Persons
{
    public abstract class Person : BaseModifiableDomainEntity
    {
        public const int MaxFistNameLength = 50;
        public const int MaxLastNameLength = 50;
        public const int MaxNationalCodeLength = 20;




        [Required, MaxLength(MaxFistNameLength)]
        public string FirstName { get; set; }
        [Required, MaxLength(MaxLastNameLength)]
        public string LastName { get; set; }
        [Required, MaxLength(MaxNationalCodeLength)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string NationalCode { get; set; }
    }
}

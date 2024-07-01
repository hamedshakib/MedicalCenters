using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCenters.Domain.Entities.Base;

namespace MedicalCenters.Domain.Entities.Persons
{
    public abstract class Person : BaseModifiableDomainEntity
    {
        public const int MaxFistNameLenght = 50;
        public const int MaxLastNameLenght = 50;
        public const int MaxNationalCodeLenght = 20;




        [Required, MaxLength(MaxFistNameLenght)]
        public string FirstName { get; set; }
        [Required, MaxLength(MaxLastNameLenght)]
        public string LastName { get; set; }
        [Required, MaxLength(MaxNationalCodeLenght)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string NationalCode { get; set; }
    }
}

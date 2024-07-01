using System.ComponentModel.DataAnnotations;


namespace MedicalCenters.Domain.Entities.Persons
{
    public abstract class Personnel : Person
    {
        public const int MaxPersonnelCodeLength = 50;

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(MaxPersonnelCodeLength)]
        public string PersonnelCode { get; set; }
    }
}

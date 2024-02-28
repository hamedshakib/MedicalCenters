namespace MedicalCenters.Application.DTOs.Medicine
{
    public class CreateMedicineDto : IMedicineDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
    }
}

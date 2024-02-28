namespace MedicalCenters.Application.DTOs.Medicine
{
    public class MedicineDto : BaseDto, IMedicineDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
    }
}

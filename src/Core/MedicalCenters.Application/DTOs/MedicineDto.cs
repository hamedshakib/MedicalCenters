namespace MedicalCenters.Application.DTOs
{
    public record MedicineDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
    }
}

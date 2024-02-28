namespace MedicalCenters.Application.DTOs.MedicalCenter
{
    public class CreateMedicalCenterDto : IMedicalCenterDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public string Address { get; set; }
        public double GPSx { get; set; }
        public double GPSy { get; set; }

    }
}

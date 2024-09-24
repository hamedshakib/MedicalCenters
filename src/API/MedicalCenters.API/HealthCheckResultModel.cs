namespace MedicalCenters.API
{
    public record HealthCheckResultModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}

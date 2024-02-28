namespace MedicalCenters.Application.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; } = false;
        public IList<ErrorResponse>? Errors { get; set; }
    }
}

namespace MedicalCenters.Application.Responses
{
    public class BaseValuedCommandResponse<T> : BaseResponse
    {
        public T? Id { get; set; }
    }
}

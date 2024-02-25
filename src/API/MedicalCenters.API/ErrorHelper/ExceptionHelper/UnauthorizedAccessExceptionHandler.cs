using MedicalCenters.Domain.Enums;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class UnauthorizedAccessExceptionHandler(UnauthorizedAccessException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.UnAuthroze, "شما اجازه دسترسی به این قسمت را ندارید"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status403Forbidden;
            return objectResult;
        }
    }
}

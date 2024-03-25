using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Enums;
using MedicalCenters.Identity.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class RefreshTokenFailedExceptionHandler(RefreshTokenFailedException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse(((int)ErrorEnums.RefreshTokenFailed), $"تجدید توکن با موفقیت انجام نشد، لطفا مجددا لاگین نمایید"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status403Forbidden;
            return objectResult;
        }
    }
}

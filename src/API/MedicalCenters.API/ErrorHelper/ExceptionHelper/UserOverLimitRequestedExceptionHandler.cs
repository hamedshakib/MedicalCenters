using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Enums;
using MedicalCenters.Identity.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class UserOverLimitRequestedExceptionHandler(UserOverLimitRequestedException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.UserOverLimitRequested, "شما بیش از حد مجاز به سرور درخواست ارسال کرده اید "));

            objectResult = new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status429TooManyRequests
            };
            return objectResult;
        }
    }
}

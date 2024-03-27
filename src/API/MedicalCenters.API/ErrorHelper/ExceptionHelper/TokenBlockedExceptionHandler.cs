using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Enums;
using MedicalCenters.Identity.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class TokenBlockedExceptionHandler(TokenBlockedException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.TokenBlocked, $"توکن شما مسدود شده است"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status406NotAcceptable;
            return objectResult;
        }
    }
}

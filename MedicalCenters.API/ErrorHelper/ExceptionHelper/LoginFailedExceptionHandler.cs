using MedicalCenters.Application.Contracts.Error;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class LoginFailedExceptionHandler(LoginFailedException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.LoginFailed, ex.Message));

            objectResult = new ObjectResult(response);
            if (ex.IsUserFound)
                objectResult.StatusCode = StatusCodes.Status400BadRequest;
            else
                objectResult.StatusCode = StatusCodes.Status404NotFound;
            return objectResult;
        }
    }
}

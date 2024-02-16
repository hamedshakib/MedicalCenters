using MedicalCenters.Domain.Enums;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class NotFoundExceptionHandler(NotFoundException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.NotFound, $" {ex.NotFound_ObjectType} با شناسه '{ex.Id}' یافت نشد"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status400BadRequest;
            return objectResult;
        }
    }
}

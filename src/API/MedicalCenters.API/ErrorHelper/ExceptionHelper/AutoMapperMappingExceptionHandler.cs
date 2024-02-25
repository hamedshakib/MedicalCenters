using AutoMapper;
using MedicalCenters.Domain.Enums;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class AutoMapperMappingExceptionHandler(AutoMapperMappingException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse(((int)ErrorEnums.ConvertData), $"در تبدیل  {ex.MemberMap} خطایی رخ داد"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status400BadRequest;
            return objectResult;
        }
    }
}

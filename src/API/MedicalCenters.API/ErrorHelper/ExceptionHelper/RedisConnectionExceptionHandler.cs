using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class RedisConnectionExceptionHandler(RedisConnectionException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.Query, $"ارتباط با سرور Redis برقرار نشد"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status500InternalServerError;
            return objectResult;
        }
    }
}

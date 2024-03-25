using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class DbExceptionHandler(DbException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {

            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.Query, $"در کوئری به دیتابیس خطایی رخ داد"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status500InternalServerError;
            return objectResult;
        }
    }
}

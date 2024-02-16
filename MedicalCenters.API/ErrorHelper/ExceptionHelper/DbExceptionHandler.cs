using MedicalCenters.Domain.Enums;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class DbExceptionHandler(DbException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {

            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.Query, $"در کوئری به دیتابیس خطایی رخ داد"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status400BadRequest;
            return objectResult;
        }
    }
}

using MedicalCenters.Domain.Enums;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class DbUpdateExceptionHandler(DbUpdateException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.Query, $"در هنگام ذخیره داده مورد نظر خطایی رخ داد"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status400BadRequest;
            return objectResult;
        }
    }
}

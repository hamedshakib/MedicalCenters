using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class TaskCanceledExceptionHandler(TaskCanceledException ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = new List<ErrorResponse>();
            response.Errors.Add(new ErrorResponse((int)ErrorEnums.TaskCanceled, $"از ادامه روند انصراف داده شد"));

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status406NotAcceptable;
            return objectResult;
        }
    }
}

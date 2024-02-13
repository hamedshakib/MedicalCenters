using MedicalCenters.Application.Contracts.Error;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

using MedicalCenters.API.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class DefaultExceptionHandler(Exception ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = ex.ErrorsResponse();

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status500InternalServerError;
            return objectResult;
        }
    }
}

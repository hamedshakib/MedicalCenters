using MedicalCenters.API.Utility.Extentions;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public class DefaultExceptionHandler(Exception ex) : BaseExceptionHandler
    {
        public override ObjectResult ProcessException()
        {
            response.Errors = ex.ErrorsResponse();

            objectResult = new ObjectResult(response);
            objectResult.StatusCode = StatusCodes.Status400BadRequest;
            return objectResult;
        }
    }
}

using MedicalCenters.API.Utility.Extentions;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.API.ErrorHelper
{
    public static class ErrorHelper
    {
        public static ObjectResult ToObjectResult(this Exception exception)
        {
            BaseQueryResponse result = default;
            ObjectResult objectResult = default;

            switch (exception)
            {
                case ValidationException ex:
                    result = new BaseQueryResponse()
                    {
                        IsSusses = false,
                        Errors = ex.ErrorsResponse()
                    };
                    objectResult = new ObjectResult(result);
                    objectResult.StatusCode = StatusCodes.Status400BadRequest;
                    return objectResult;
                default:
                    result = new BaseQueryResponse()
                    {
                        IsSusses = false,
                        Errors = exception.ErrorsResponse()
                    };
                    objectResult = new ObjectResult(result);
                    objectResult.StatusCode = StatusCodes.Status400BadRequest;
                    return objectResult;
            }
        }
    }
}

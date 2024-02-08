using AutoMapper;
using MedicalCenters.API.Utility.Extentions;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace MedicalCenters.API.ErrorHelper
{
    public static class ErrorHelper
    {
        public static ObjectResult ToObjectResult(this Exception exception)
        {
            BaseQueryResponse result = default;
            ObjectResult objectResult = default;

            List<ErrorResponse> Errors = null;

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
                case AutoMapperMappingException ex:
                    Errors = new List<ErrorResponse>();
                    Errors.Add(new ErrorResponse(10, $"در تبدیل  {ex.MemberMap} خطایی رخ داد"));
                    result = new BaseQueryResponse()
                    {
                        IsSusses = false,
                        Errors = Errors
                    };
                    objectResult = new ObjectResult(result);
                    objectResult.StatusCode = StatusCodes.Status400BadRequest;
                    return objectResult;
                case NotFoundException ex:
                    Errors = new List<ErrorResponse>();
                    Errors.Add(new ErrorResponse(10, $" {ex.NotFound_Object} مورد نظر یافت نشد"));
                    result = new BaseQueryResponse()
                    {
                        IsSusses = false,
                        Errors = Errors
                    };
                    objectResult = new ObjectResult(result);
                    objectResult.StatusCode = StatusCodes.Status404NotFound;
                    return objectResult;
                case DbException ex:
                    Errors = new List<ErrorResponse>();
                    string DBError = $"در کوئری به دیتابیس خطایی رخ داد";
                    Errors.Add(new ErrorResponse(10, DBError));
                    result = new BaseQueryResponse()
                    {
                        IsSusses = false,
                        Errors = Errors
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

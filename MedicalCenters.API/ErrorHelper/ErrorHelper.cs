using AutoMapper;
using MedicalCenters.API.Utility.Extentions;
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
                    var Errors = new List<ErrorResponse>();
                    string Error = $"در تبدیل  {ex.MemberMap} خطایی رخ داد";
                    Errors.Add(new ErrorResponse(10, Error));
                    result = new BaseQueryResponse()
                    {
                        IsSusses = false,
                        Errors = Errors
                    };
                    objectResult = new ObjectResult(result);
                    objectResult.StatusCode = StatusCodes.Status400BadRequest;
                    return objectResult;
                case DbException ex:
                    var DbErrors = new List<ErrorResponse>();
                    string DBError = $"در کوئری به دیتابیس خطایی رخ داد";
                    DbErrors.Add(new ErrorResponse(10, DBError));
                    result = new BaseQueryResponse()
                    {
                        IsSusses = false,
                        Errors = DbErrors
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

using AutoMapper;
using MedicalCenters.API.Utility.Extentions;
using MedicalCenters.Application.Contracts.Error;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Exceptions;
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
                    Errors.Add(new ErrorResponse(((int)ErrorEnums.ConvertData), $"در تبدیل  {ex.MemberMap} خطایی رخ داد"));
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
                    Errors.Add(new ErrorResponse((int)ErrorEnums.NotFound, $" {ex.NotFound_Object} مورد نظر یافت نشد"));
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
                    Errors.Add(new ErrorResponse((int)ErrorEnums.Query, DBError));
                    result = new BaseQueryResponse()
                    {
                        IsSusses = false,
                        Errors = Errors
                    };
                    objectResult = new ObjectResult(result);
                    objectResult.StatusCode = StatusCodes.Status400BadRequest;
                    return objectResult;
                case LoginFailedException ex:
                    result = new BaseQueryResponse()
                    {
                        IsSusses = false,
                        Errors = new List<ErrorResponse>() { new ErrorResponse((int)ErrorEnums.LoginFailed, ex.Message) }
                    };
                    objectResult = new ObjectResult(result);
                    if(ex.IsUserFound)
                        objectResult.StatusCode = StatusCodes.Status400BadRequest;
                    else
                        objectResult.StatusCode = StatusCodes.Status404NotFound;
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

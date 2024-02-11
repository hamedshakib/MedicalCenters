using AutoMapper;
using FluentValidation;
using MedicalCenters.API.ErrorHelper.ExceptionHelper;
using MedicalCenters.API.Utility.Extentions;
using MedicalCenters.Application.Contracts.Error;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace MedicalCenters.API.ErrorHelper
{
    public static class ExceptionHandler
    {
        public static ObjectResult ToObjectResult(this Exception exception)
        {
            BaseQueryResponse result = default;
            ObjectResult objectResult = default;

            List<ErrorResponse> Errors = null;
            BaseExceptionHandler handler = null;

            switch (exception)
            {
                case ValidationException ex:
                    handler = new ValidationExceptionHandler(ex);
                    return handler.ProcessException();

                case AutoMapperMappingException ex:
                    handler = new AutoMapperMappingExceptionHandler(ex);
                    return handler.ProcessException();

                case NotFoundException ex:
                    handler = new NotFoundExceptionHandler(ex);
                    return handler.ProcessException();

                case DbException ex:
                    handler = new DbExceptionHandler(ex);
                    return handler.ProcessException();

                case LoginFailedException ex:
                    handler = new LoginFailedExceptionHandler(ex);
                    return handler.ProcessException();

                case UnauthorizedAccessException ex:
                    handler = new UnauthorizedAccessExceptionHandler(ex);
                    return handler.ProcessException();

                default:
                    handler = new DefaultExceptionHandler(exception);
                    return handler.ProcessException();
            }
        }
    }
}

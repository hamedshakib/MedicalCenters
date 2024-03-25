using AutoMapper;
using FluentValidation;
using MedicalCenters.API.ErrorHelper.ExceptionHelper;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Data.Common;

namespace MedicalCenters.API.ErrorHelper
{
    public class ExceptionHandler : IExceptionHandler
    {
        public ObjectResult ProcessException(Exception exception)
        {
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

                case RefreshTokenFailedException ex:
                    handler = new RefreshTokenFailedExceptionHandler(ex);
                    return handler.ProcessException();

                case DbUpdateException ex:
                    handler = new DbUpdateExceptionHandler(ex);
                    return handler.ProcessException();
                case UserOverLimitRequestedException ex:
                    handler = new UserOverLimitRequestedExceptionHandler(ex);
                    return handler.ProcessException();

                case TokenBlockedException ex:
                    handler = new TokenBlockedExceptionHandler(ex);
                    return handler.ProcessException();

                case RedisConnectionException ex:
                    handler = new RedisConnectionExceptionHandler(ex);
                    return handler.ProcessException();

                default:
                    handler = new DefaultExceptionHandler(exception);
                    return handler.ProcessException();
            }
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ObjectResult objectResult = ProcessException(exception);
            httpContext.Response.StatusCode = objectResult.StatusCode.Value;
            await httpContext.Response.WriteAsJsonAsync(objectResult.Value, cancellationToken);
            return true;
        }
    }
}

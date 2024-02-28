using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.ErrorHelper.ExceptionHelper
{
    public abstract class BaseExceptionHandler
    {
        protected BaseQueryResponse response = new BaseQueryResponse() { IsSuccess = false };
        protected ObjectResult objectResult;

        public abstract ObjectResult ProcessException();
    }
}

using FluentValidation;
using FluentValidation.Results;
using MedicalCenters.Application.Contracts.Error;
using MedicalCenters.Application.Responses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace MedicalCenters.API.Utility.Extentions
{
    public static class ExceptionHelper
    {
        public static IList<ErrorResponse> ErrorsResponse(this ValidationException exception)
        {
            var Errors = new List<ErrorResponse>();
            var ValidationFailureList = (List<ValidationFailure>)exception.Errors;
            ValidationFailureList.ForEach(x => Errors.Add(new ErrorResponse((int)ErrorEnums.Validation, x.ErrorMessage)));
            return Errors;
        }

        public static IList<ErrorResponse> ErrorsResponse(this Exception exception)
        {
            var Errors = new List<ErrorResponse>();
            Errors.Add(new ErrorResponse((int)ErrorEnums.UnKnown, exception.Message));
            return Errors;
        }
    }
}

using FluentValidation.Results;
using MedicalCenters.Application.Responses;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.API.Utility.Extentions
{
    public static class ExceptionHelper
    {
        public static IList<ErrorResponse> ErrorsResponse(this ValidationException exception)
        {
            var Errors = new List<ErrorResponse>();
            var ValidationFailureList = (List<ValidationFailure>)exception.Value;
            ValidationFailureList.ForEach(x => Errors.Add(new ErrorResponse(Convert.ToInt32(x.ErrorCode), x.ErrorMessage)));
            return Errors;
        }

        public static IList<ErrorResponse> ErrorsResponse(this Exception exception)
        {
            var Errors = new List<ErrorResponse>();
            Errors.Add(new ErrorResponse(-1, exception.Message));
            return Errors;
        }
    }
}

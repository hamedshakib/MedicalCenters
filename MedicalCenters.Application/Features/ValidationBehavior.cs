using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IList<IValidator<IRequest>> _validators;
        public ValidationBehavior(IList<IValidator<IRequest>> validators)
        {
            _validators= validators;
        }
        Task<TResponse> IPipelineBehavior<TRequest, TResponse>.Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            var validationContext = new ValidationContext<TRequest>(request);
            var validationFailures=_validators.Select(x => x.Validate(validationContext))
                                              .SelectMany(x => x.Errors)
                                              .Where(x => x != null)
                                              .ToList();
            if(validationFailures.Any()) 
            {
                throw new ValidationException(validationFailures);
            }

            return next();
        }
    }
}

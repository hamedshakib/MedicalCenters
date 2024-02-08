using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MedicalCenters.Application.DTOs.MedicalCenter;

namespace MedicalCenters.Application.Features.MedicalCenter.Validates
{
    internal class CreateMedicalCenterCommandValidator : AbstractValidator<CreateMedicalCenterDto>
    {
        public CreateMedicalCenterCommandValidator()
        {
            RuleFor(e => e.Name).NotNull().WithErrorCode("1000").WithMessage("{PropertyName} is null");
            RuleFor(e => e.Name).NotEmpty().WithErrorCode("1001").WithMessage("{PropertyName} is empty");
        }
    }
}

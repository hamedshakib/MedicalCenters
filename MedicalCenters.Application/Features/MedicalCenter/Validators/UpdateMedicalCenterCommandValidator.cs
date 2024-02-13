using FluentValidation;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Validates
{
    internal class UpdateMedicalCenterCommandValidator : AbstractValidator<UpdateMedicalCenterCommand>
    {
        public UpdateMedicalCenterCommandValidator()
        {
            RuleFor(e => e.MedicalCenterDto.Name).NotNull().WithErrorCode("1000").WithMessage("{PropertyName} is null");
            RuleFor(e => e.MedicalCenterDto.Name).NotEmpty().WithErrorCode("1001").WithMessage("{PropertyName} is empty");
        }
    }
}

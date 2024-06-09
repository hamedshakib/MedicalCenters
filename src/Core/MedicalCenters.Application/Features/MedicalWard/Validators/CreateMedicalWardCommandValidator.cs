﻿using FluentValidation;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;

namespace MedicalCenters.Application.Features.MedicalWard.Validators
{
    internal class CreateMedicalWardCommandValidator : AbstractValidator<CreateMedicalWardCommand>
    {
        public CreateMedicalWardCommandValidator()
        {
            RuleFor(e => e.MedicalWardDto.Name).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
            RuleFor(e => e.MedicalWardDto.TypeId).NotNull();
            RuleFor(e => e.MedicalWardDto.MedicalCenterId).NotNull();
        }
    }
}

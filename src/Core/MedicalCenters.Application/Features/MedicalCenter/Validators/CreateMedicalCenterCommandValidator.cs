﻿using FluentValidation;
using MedicalCenters.Application.Features.MedicalCenter.Commands;

namespace MedicalCenters.Application.Features.MedicalCenter.Validates
{
    internal class CreateMedicalCenterCommandValidator : AbstractValidator<CreateMedicalCenterCommand>
    {
        private string NullOrEmptyMessage = "{PropertyName} is null or Empty";
        private string NullMessage = "{PropertyName} is null";
        public CreateMedicalCenterCommandValidator()
        {

            RuleFor(e => e.MedicalCenterDto.Name).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
            RuleFor(e => e.MedicalCenterDto.TypeId).NotNull();
            When(x => x.MedicalCenterDto.GPSx != null || x.MedicalCenterDto.GPSy != null, () =>
            {
                RuleFor(x => x.MedicalCenterDto.GPSx).GreaterThanOrEqualTo(-90).WithMessage("GPSx must Greater than -90");
                RuleFor(x => x.MedicalCenterDto.GPSx).LessThanOrEqualTo(+90).WithMessage("GPSx must Less than -90");

                RuleFor(x => x.MedicalCenterDto.GPSy).GreaterThanOrEqualTo(-180).WithMessage("GPSy must Greater than -180");
                RuleFor(x => x.MedicalCenterDto.GPSy).LessThanOrEqualTo(+180).WithMessage("GPSy must Less than -180");
            });
        }
    }
}

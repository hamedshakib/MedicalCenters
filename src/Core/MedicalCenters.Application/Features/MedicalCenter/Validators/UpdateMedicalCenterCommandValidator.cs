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
            RuleFor(e => e.MedicalCenterDto.Id).NotNull();
            RuleFor(e => e.MedicalCenterDto.TypeId).NotNull();
            RuleFor(e => e.MedicalCenterDto.Name).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
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

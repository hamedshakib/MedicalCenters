using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;

namespace MedicalCenters.Application.Features.MedicalCenter.Validates
{
    internal class CreateMedicalCenterCommandValidator : AbstractValidator<CreateMedicalCenterCommand>
    {
        private string NullMessage = "{PropertyName} is null or Empty";
        public CreateMedicalCenterCommandValidator()
        {

            RuleFor(e => e.CreateMedicalCenterDto.Name).NotNull().NotEmpty().WithMessage(NullMessage);
            RuleFor(e => e.CreateMedicalCenterDto.TypeId).NotNull().NotEmpty().WithMessage(NullMessage);
            When(x => x.CreateMedicalCenterDto.GPSx!= null || x.CreateMedicalCenterDto.GPSy != null, () =>
            { 
                RuleFor(x => x.CreateMedicalCenterDto.GPSx).GreaterThanOrEqualTo(-90).WithMessage("GPSx must Greater than -90");
                RuleFor(x => x.CreateMedicalCenterDto.GPSx).LessThanOrEqualTo(+90).WithMessage("GPSx must Less than -90");

                RuleFor(x => x.CreateMedicalCenterDto.GPSy).GreaterThanOrEqualTo(-180).WithMessage("GPSy must Greater than -180");
                RuleFor(x => x.CreateMedicalCenterDto.GPSy).LessThanOrEqualTo(+180).WithMessage("GPSy must Less than -180");
            });
        }
    }
}

using FluentValidation;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Validators
{
    internal class UpdateMedicalWardCommandValidator : AbstractValidator<UpdateMedicalWardCommand>
    {
        public UpdateMedicalWardCommandValidator()
        {
            RuleFor(e => e.MedicalWardDto.Id).NotNull();
            RuleFor(e => e.MedicalWardDto.Name).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
            RuleFor(e => e.MedicalWardDto.TypeId).NotNull();
            RuleFor(e => e.MedicalWardDto.MedicalCenterId).NotNull();
        }
    }
}

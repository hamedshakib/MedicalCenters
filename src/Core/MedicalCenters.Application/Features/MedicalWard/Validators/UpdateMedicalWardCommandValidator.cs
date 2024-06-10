using FluentValidation;
using MedicalCenters.Application.Features.MedicalWard.Commands;

namespace MedicalCenters.Application.Features.MedicalWard.Validators
{
    internal class UpdateMedicalWardCommandValidator : AbstractValidator<UpdateMedicalWardCommand>
    {
        public UpdateMedicalWardCommandValidator()
        {
            RuleFor(e => e.MedicalWardDto.Name).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
            RuleFor(e => e.MedicalWardDto.TypeId).NotNull();
            RuleFor(e => e.MedicalWardDto.MedicalCenterId).NotNull();
        }
    }
}

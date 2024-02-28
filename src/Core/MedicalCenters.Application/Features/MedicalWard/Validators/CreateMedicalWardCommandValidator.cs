using FluentValidation;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;

namespace MedicalCenters.Application.Features.MedicalWard.Validators
{
    internal class CreateMedicalWardCommandValidator : AbstractValidator<CreateMedicalWardCommand>
    {
        public CreateMedicalWardCommandValidator()
        {
            RuleFor(e => e.CreateMedicalWardDto.Name).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
            RuleFor(e => e.CreateMedicalWardDto.TypeId).NotNull();
            RuleFor(e => e.CreateMedicalWardDto.MedicalCenterId).NotNull();
        }
    }
}

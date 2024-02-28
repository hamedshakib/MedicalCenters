using FluentValidation;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;

namespace MedicalCenters.Application.Features.MedicalWard.Validators
{
    internal class DeleteMedicalWardCommandValidator : AbstractValidator<DeleteMedicalWardCommand>
    {
        public DeleteMedicalWardCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
        }
    }
}

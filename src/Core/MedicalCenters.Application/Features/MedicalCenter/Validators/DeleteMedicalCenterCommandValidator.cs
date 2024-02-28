using FluentValidation;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;

namespace MedicalCenters.Application.Features.MedicalCenter.Validates
{
    internal class DeleteMedicalCenterCommandValidator : AbstractValidator<DeleteMedicalCenterCommand>
    {
        public DeleteMedicalCenterCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
        }
    }
}

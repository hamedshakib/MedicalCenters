using FluentValidation;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

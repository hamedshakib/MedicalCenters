using FluentValidation;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Validates
{
    internal class DeleteMedicalCenterCommandValidator : AbstractValidator<DeleteMedicalCenterCommand>
    {
    }
}

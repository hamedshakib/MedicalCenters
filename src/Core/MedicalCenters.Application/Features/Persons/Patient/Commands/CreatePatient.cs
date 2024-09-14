using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Entities.Persons;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.Persons.Patient.Commands
{
    public class CreatePatientCommandHandler(IPatientRepository _patientRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreatePatientCommand, BaseValuedCommandResponse<long>>
    {
        public async Task<BaseValuedCommandResponse<long>> Handle(CreatePatientCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse<long>();

            var data = mapper.Map < Domain.Entities.Persons.Patient>(command.PatientDto);
            data = await _patientRepository.AddAsync(data);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Id = data.Id;


            return response;
        }
    }
    public record CreatePatientCommand : IRequest<BaseValuedCommandResponse<long>>
    {
        public PatientDto PatientDto { get; set; }
    }

    internal class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(e => e.PatientDto.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(Domain.Entities.Persons.Patient.MaxFistNameLength);
            RuleFor(e => e.PatientDto.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(Domain.Entities.Persons.Patient.MaxLastNameLength);
            RuleFor(e => e.PatientDto.NationalCode).NotNull().NotEmpty().MaximumLength(Domain.Entities.Persons.Patient.MaxNationalCodeLength);
        }
    }
}

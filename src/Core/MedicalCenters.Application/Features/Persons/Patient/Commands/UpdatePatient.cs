using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using MedicalCenters.Domain.Entities.Persons;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Persons.Patient.Commands
{
    internal class UpdatePatientCommandHandler(IPatientRepository _patientRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdatePatientCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var patient = await _patientRepository.GetAsync(command.Id);
            if (patient is null)
            {
                throw new NotFoundException(Domain.Entities.Persons.Patient.EntityTitle, command.Id.ToString());
            }

            mapper.Map(command.PatientDto, patient);

            await _patientRepository.UpdateAsync(patient);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;



            return response;
        }
    }
    public record UpdatePatientCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
        public PatientDto PatientDto { get; set; }
    }

    internal class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
            RuleFor(e => e.PatientDto.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(Domain.Entities.Persons.Patient.MaxFistNameLenght);
            RuleFor(e => e.PatientDto.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(Domain.Entities.Persons.Patient.MaxLastNameLenght);
            RuleFor(e => e.PatientDto.NationalCode).NotNull().NotEmpty().MaximumLength(Domain.Entities.Persons.Patient.MaxNationalCodeLenght);        }
    }
}

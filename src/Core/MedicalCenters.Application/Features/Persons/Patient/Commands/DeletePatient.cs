using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.Persons.Patient.Commands
{
    internal class DeletePatientCommandHandler(IPatientRepository _patientRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeletePatientCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeletePatientCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (!await _patientRepository.ExistAsync(command.Id))
            {
                throw new NotFoundException(Domain.Entities.Persons.Patient.EntityTitle, command.Id.ToString());
            }

            await _patientRepository.DeleteAsync((int)command.Id);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            response.IsSuccess = true;

            return response;
        }
    }
    public record DeletePatientCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
    internal class DeletePatientCommandValidator : AbstractValidator<DeletePatientCommand>
    {
        public DeletePatientCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
        }
    }
}

using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Persons.Patient.Commands
{
    internal class DeletePatientCommandHandler(IPatientRepository PatientRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeletePatientCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeletePatientCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (!await PatientRepository.Exist((int)command.Id))
            {
                throw new NotFoundException("پزشک", command.Id.ToString());
            }

            await PatientRepository.Delete((int)command.Id);
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

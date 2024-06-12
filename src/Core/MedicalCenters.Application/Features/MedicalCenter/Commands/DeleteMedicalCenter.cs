using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalCenter.Commands;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Commands
{
    internal class DeleteMedicalCenterCommandHandler(IMedicalCenterRepository medicalCenterRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMedicalCenterCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (!await medicalCenterRepository.Exist((int)command.Id))
            {
                throw new NotFoundException(Domain.Entities.MedicalCenter.EntityTitle, command.Id.ToString());
            }

            await medicalCenterRepository.Delete((int)command.Id);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            response.IsSuccess = true;

            return response;
        }
    }

    public record DeleteMedicalCenterCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
    internal class DeleteMedicalCenterCommandValidator : AbstractValidator<DeleteMedicalCenterCommand>
    {
        public DeleteMedicalCenterCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
        }
    }
}

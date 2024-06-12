using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalWard.Commands;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Commands
{
    internal class CreateMedicalWardCommandHandler(IMedicalWardRepository medicalWardRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateMedicalWardCommand, BaseValuedCommandResponse<int>>
    {
        public async Task<BaseValuedCommandResponse<int>> Handle(CreateMedicalWardCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse<int>();

            var data = mapper.Map<MedicalCenters.Domain.Entities.MedicalWard>(command.MedicalWardDto);
            data = await medicalWardRepository.Add(data);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Id = data.Id;


            return response;
        }
    }
    public class CreateMedicalWardCommand : IRequest<BaseValuedCommandResponse<int>>
    {
        public MedicalWardDto MedicalWardDto { get; set; }
    }
    internal class CreateMedicalWardCommandValidator : AbstractValidator<CreateMedicalWardCommand>
    {
        public CreateMedicalWardCommandValidator()
        {
            RuleFor(e => e.MedicalWardDto.Name).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(e => e.MedicalWardDto.TypeId).NotNull();
            RuleFor(e => e.MedicalWardDto.MedicalCenterId).NotNull();
        }
    }
}

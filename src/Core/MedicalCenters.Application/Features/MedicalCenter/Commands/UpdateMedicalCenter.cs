using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
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
    internal class UpdateMedicalCenterCommandHandler(IMedicalCenterRepository medicalCenterRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateMedicalCenterCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var medicalCenter = await medicalCenterRepository.Get(command.Id);
            if (medicalCenter is null)
            {
                throw new NotFoundException(Domain.Entities.MedicalCenter.EntityTitle, command.Id.ToString());
            }

            mapper.Map(command.MedicalCenterDto, medicalCenter);

            await medicalCenterRepository.Update(medicalCenter);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;



            return response;
        }
    }
    public record UpdateMedicalCenterCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public MedicalCenterDto MedicalCenterDto { get; set; }
    }

    internal class UpdateMedicalCenterCommandValidator : AbstractValidator<UpdateMedicalCenterCommand>
    {
        public UpdateMedicalCenterCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(e => e.MedicalCenterDto.TypeId).NotNull();
            RuleFor(e => e.MedicalCenterDto.Name).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            When(x => x.MedicalCenterDto.GPSx != null || x.MedicalCenterDto.GPSy != null, () =>
            {
                RuleFor(x => x.MedicalCenterDto.GPSx).GreaterThanOrEqualTo(-90).WithMessage("GPSx must Greater than -90");
                RuleFor(x => x.MedicalCenterDto.GPSx).LessThanOrEqualTo(+90).WithMessage("GPSx must Less than -90");

                RuleFor(x => x.MedicalCenterDto.GPSy).GreaterThanOrEqualTo(-180).WithMessage("GPSy must Greater than -180");
                RuleFor(x => x.MedicalCenterDto.GPSy).LessThanOrEqualTo(+180).WithMessage("GPSy must Less than -180");
            });
        }
    }
}

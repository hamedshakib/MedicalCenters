using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalCenter.Commands;
using MedicalCenters.Application.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.MedicalCenter.Commands
{
    internal class CreateMedicalCenterCommandHandler(IMedicalCenterRepository medicalCenterRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateMedicalCenterCommand, BaseValuedCommandResponse<int>>
    {
        public async Task<BaseValuedCommandResponse<int>> Handle(CreateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse<int>();

            var data = mapper.Map<Domain.Entities.MedicalCenter_Parts.MedicalCenter>(command.MedicalCenterDto);
            data = await medicalCenterRepository.AddAsync(data);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Id = data.Id;



            return response;
        }
    }
    public record CreateMedicalCenterCommand : IRequest<BaseValuedCommandResponse<int>>
    {
        public MedicalCenterDto MedicalCenterDto { get; set; }
    }

    internal class CreateMedicalCenterCommandValidator : AbstractValidator<CreateMedicalCenterCommand>
    {
        private string NullOrEmptyMessage = "{PropertyName} is null or Empty";
        private string NullMessage = "{PropertyName} is null";
        public CreateMedicalCenterCommandValidator()
        {

            RuleFor(e => e.MedicalCenterDto.Name).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(e => e.MedicalCenterDto.TypeId).NotNull();
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

using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Features.MedicalCenter.Validates;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Validations;

namespace MedicalCenters.Application.Features.MedicalCenter.Handlers.Commands
{
    internal class CreateMedicalCenterCommandHandler : IRequestHandler<CreateMedicalCenterCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateMedicalCenterCommandHandler(IUnitOfWork unitOfWork, IMedicalCenterRepository medicalCenterRepository)
        {
            
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(CreateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMedicalCenterCommandValidator();
            var validationResult = await validator.ValidateAsync(command.CreateMedicalCenterDto);
            if (!validationResult.IsValid)
            {
                response.IsSusses = false;
                response.Errors= validationResult.Errors.ErrorMessages();
                return response;
            }
            try
            {
                var data = ProcessData(command.CreateMedicalCenterDto);
                data = await _unitOfWork.MedicalCenterRepository.Add(data);
                await _unitOfWork.Save();

                response.IsSusses = true;
                response.Id = data.Id;
            }
            catch (Exception ex)
            {
                response.IsSusses= false;
                response.Errors.Add(ex.Message);
            }


            return response;
        }

        private MedicalCenters.Domain.Classes.MedicalCenter ProcessData(CreateMedicalCenterDto dto)
        {
            var createMedicalCenter = new MedicalCenters.Domain.Classes.MedicalCenter()
            {
                Name = dto.Name,
                Description = dto.Description,
            };
            return createMedicalCenter;
        }
    }
}

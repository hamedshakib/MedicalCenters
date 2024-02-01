using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Features.MedicalCenter.Validates;
using MedicalCenters.Application.Responses;

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
                response.Errors = validationResult.Errors.Select(x => 
                                                        new ErrorResponse(Convert.ToInt16(x.ErrorCode), x.ErrorMessage))
                                                                .ToList();
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
                response.Errors ??= new List<ErrorResponse>();
                response.Errors.Add(new ErrorResponse(-1,ex.Message));
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

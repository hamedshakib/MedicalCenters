using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Features.MedicalCenter.Validates;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalCenter.Handlers.Commands
{
    internal class CreateMedicalCenterCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<CreateMedicalCenterCommand, BaseValuedCommandResponse>
    {
        public async Task<BaseValuedCommandResponse> Handle(CreateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse();
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
                var data = mapper.Map<MedicalCenters.Domain.Classes.MedicalCenter>(command.CreateMedicalCenterDto);
                data = await unitOfWork.MedicalCenterRepository.Add(data);
                await unitOfWork.Save();

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
    }
}

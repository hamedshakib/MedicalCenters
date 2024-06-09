using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Requests.Commands;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Handlers.Commands
{
    internal class UpdateMedicineCommandHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateMedicineCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var medicalWard = await unitOfWork.MedicineRepository.Get(command.Id);
            if (medicalWard is null)
            {
                throw new NotFoundException("دارو", command.Id.ToString());
            }

            mapper.Map(command.MedicineDto, medicalWard);

            await unitOfWork.MedicineRepository.Update(medicalWard);
            await unitOfWork.Save();

            response.IsSuccess = true;



            return response;
        }
    }
}

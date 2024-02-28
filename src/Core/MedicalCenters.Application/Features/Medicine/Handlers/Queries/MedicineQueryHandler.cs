using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Requests.Queries;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Handlers.Queries
{
    internal class MedicineQueryHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<MedicineQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(MedicineQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await unitOfWork.MedicineRepository.Get((int)request.Id, cancellationToken);
            if (result == null)
            {
                throw new NotFoundException("دارو", request.Id.ToString());
            }

            var dto = mapper.Map<MedicineDto>(result);

            response.Data = dto;
            response.IsSuccess = true;

            return response;
        }
    }
}

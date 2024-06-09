using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Queries;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalCenter.Handlers.Queries
{
    internal class AllMedicalCenterQueryHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AllMedicalCentersQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(AllMedicalCentersQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await unitOfWork.MedicalCenterRepository.GetAll(cancellationToken);

            List<MedicalCenterDto> dtos = new List<MedicalCenterDto>();
            result.ToList().ForEach(x => dtos.Add(mapper.Map<MedicalCenterDto>(x)));

            response.Data = dtos;
            response.IsSuccess = true;


            return response;
        }
    }
}

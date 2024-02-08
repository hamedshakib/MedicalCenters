using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.Features.MedicalWard.Requests.Queries;
using MedicalCenters.Application.Responses;


namespace MedicalCenters.Application.Features.MedicalWard.Handlers.Queries
{
    internal class AllMedicalCenterWardsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AllMedicalCenterWardsQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(AllMedicalCenterWardsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();

            var result = await unitOfWork.MedicalWardRepository.GetAllMedicalCenterWards(request.MedicalCenterId);

            List <MedicalWardDto> dtos = new List<MedicalWardDto>();
            result.ToList().ForEach(x => dtos.Add(mapper.Map<MedicalWardDto>(x)));

            response.Data = dtos;
            response.IsSusses = true;


            return response;
        }
    }
}

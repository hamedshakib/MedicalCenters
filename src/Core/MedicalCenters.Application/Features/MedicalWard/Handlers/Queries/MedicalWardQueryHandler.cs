using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalWard.Requests.Queries;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalWard.Handlers.Queries
{
    internal class MedicalWardQueryHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<MedicalWardQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(MedicalWardQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await unitOfWork.MedicalWardRepository.Get((int)request.Id, cancellationToken);
            if (result == null)
            {
                throw new NotFoundException("بخش درمانی", request.Id.ToString());
            }

            var dto = mapper.Map<MedicalWardDto>(result);

            response.Data = dto;
            response.IsSuccess = true;

            return response;
        }
    }
}

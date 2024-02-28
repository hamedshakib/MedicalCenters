using MediatR;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Requests.Queries
{
    public record class MedicineQuery : IRequest<BaseQueryResponse>
    {
        public long Id { get; set; }
    }
}

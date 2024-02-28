using MediatR;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Requests.Queries
{
    public record class AllMedicineTypeMedicinesQuery : IRequest<BaseQueryResponse>
    {
        public long MedicineTypeId { get; set; }
    }
}

using MediatR;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Medicine.Requests.Queries
{
    public record class AllMedicineTypeMedicinesQuery : IRequest<BaseQueryResponse>
    {
        public long MedicineTypeId { get; set; }
    }
}

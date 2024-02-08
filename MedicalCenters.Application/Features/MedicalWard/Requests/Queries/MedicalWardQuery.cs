using MediatR;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Queries
{
    public record MedicalWardQuery : IRequest<BaseQueryResponse>
    {
        public long Id { get; set; }
    }
}

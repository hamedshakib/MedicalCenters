using MediatR;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Queries
{
    public record AllMedicalCentersQuery : IRequest<BaseQueryResponse>
    {

    }
}

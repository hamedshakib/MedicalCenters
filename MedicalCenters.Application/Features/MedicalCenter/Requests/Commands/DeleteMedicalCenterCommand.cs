using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Commands
{
    public record DeleteMedicalCenterCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
}

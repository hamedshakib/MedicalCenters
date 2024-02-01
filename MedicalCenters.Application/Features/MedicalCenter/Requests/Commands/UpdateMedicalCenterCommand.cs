using MediatR;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Commands
{
    public record UpdateMedicalCenterCommand : IRequest<BaseResponse>
    {
        public MedicalCenterDto MedicalCenterDto { get; set; }
    }
}

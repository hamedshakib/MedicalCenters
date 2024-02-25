using MediatR;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Commands
{
    public record UpdateMedicalWardCommand : IRequest<BaseResponse>
    {
        public MedicalWardDto MedicalWardDto { get; set; }
    }
}

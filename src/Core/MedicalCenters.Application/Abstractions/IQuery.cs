using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MedicalCenters.Application.Abstractions
{
    public interface IQuery : IRequest<Unit>
    {
    }
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}

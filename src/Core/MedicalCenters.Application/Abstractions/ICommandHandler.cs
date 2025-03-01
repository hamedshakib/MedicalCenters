using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MedicalCenters.Application.Abstractions
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {
    }
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}

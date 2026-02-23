using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Abstraction.CQRS
{
    public interface ICommand : IRequest
    {
    }
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}

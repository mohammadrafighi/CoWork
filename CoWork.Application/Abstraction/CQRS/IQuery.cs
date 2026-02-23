using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Abstraction.CQRS
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}

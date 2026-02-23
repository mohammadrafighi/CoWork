using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Abstraction.CQRS
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {

    }
}

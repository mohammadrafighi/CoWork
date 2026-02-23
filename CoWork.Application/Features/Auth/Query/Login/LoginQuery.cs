using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Auth.Query.Login
{
    public record LoginQuery(string UserName , string Password) : IQuery<string>
    {
    }
}

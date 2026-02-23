using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Members.Command.ChangeMemberStatus
{
    public record ChangeMemberStatusCommand(Guid memberId):ICommand<bool>
    {
    }
}

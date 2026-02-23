using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
namespace CoWork.Application.Features.Members.Command.CreateMember
{
    public record CreateMemberCommand(string UserName , string passWord , string firstName , string lastName) : ICommand<Guid>
    {
    }
}

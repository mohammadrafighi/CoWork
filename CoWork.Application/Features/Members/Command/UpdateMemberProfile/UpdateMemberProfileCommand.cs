using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
namespace CoWork.Application.Features.Members.Command.UpdateMemberProfile
{
    public record UpdateMemberProfileCommand(Guid MemberId , string UserName,string FirstName ,string LastName,  string NationalCode ) : ICommand<Guid>
    {
    }
}

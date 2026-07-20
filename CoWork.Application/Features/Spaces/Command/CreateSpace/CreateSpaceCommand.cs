using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CoWork.Application.Features.Spaces.Command.CreateSpace
{
    public record CreateSpaceCommand(string Name,int BaseCapacity,decimal BasePrice):ICommand<Guid>
    {
    }
}

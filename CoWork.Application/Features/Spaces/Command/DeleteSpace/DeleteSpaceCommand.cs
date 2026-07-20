using System;
using System.Collections.Generic;
using System.Text;
using CoWork.Application.Abstraction.CQRS;
using System.Windows.Input;
using ICommand = CoWork.Application.Abstraction.CQRS.ICommand;

namespace CoWork.Application.Features.Spaces.Command.DeleteSpace
{
    public record DeleteSpaceCommand(Guid SpaceId):ICommand
    {
    }
}

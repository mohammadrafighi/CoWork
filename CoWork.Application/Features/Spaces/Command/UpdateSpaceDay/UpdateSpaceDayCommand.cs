using System;
using System.Collections.Generic;
using CoWork.Application.Abstraction.CQRS;
using System.Text;
using System.Windows.Input;
using ICommand = CoWork.Application.Abstraction.CQRS.ICommand;

namespace CoWork.Application.Features.Spaces.Command.UpdateSpaceDay
{
    public record UpdateSpaceDayCommand(Guid SpaceId,DateOnly Date):ICommand
    {

    }
}

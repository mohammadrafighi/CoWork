using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Spaces.Command.UpdateSpaceBase
{
    public record UpdateSpaceBaseCommand(Guid SpaceId,string? Name,int? BaseCapacity,decimal? BasePrice):ICommand
    {

    }
}

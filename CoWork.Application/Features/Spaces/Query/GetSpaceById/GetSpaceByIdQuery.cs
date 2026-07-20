using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Space;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Spaces.Query.GetSpaceById
{
    public record GetSpaceByIdQuery(Guid SpaceId):IQuery<SpaceDto>
    {
    }
}

using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Members.Query.GetMembers
{
    public record GetAllMembersQuery():IQuery<IEnumerable<MemberDto>>
    {
    }
}

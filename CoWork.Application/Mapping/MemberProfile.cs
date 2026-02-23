using AutoMapper;
using CoWork.Application.DTOs.Member;
using CoWork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Mapping
{
    public class MemberProfile: Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberDto>();
        }

    }
}

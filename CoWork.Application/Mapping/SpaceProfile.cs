using AutoMapper;
using CoWork.Application.DTOs.Space;
using CoWork.Application.Features.Spaces.Command.UpdateSpaceBase;
using CoWork.Domain.Spaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Mapping
{
    public class SpaceProfile:Profile
    {
        public SpaceProfile()
        {
            CreateMap<Space, SpaceDto>();
            CreateMap<UpdateSpaceBaseCommand, Space>();
        }
    }
}

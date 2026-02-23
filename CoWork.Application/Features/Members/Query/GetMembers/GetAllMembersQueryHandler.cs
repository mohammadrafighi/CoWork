using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Member;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CoWork.Application.Features.Members.Query.GetMembers
{
   
    public class GetAllMembersQueryHandler : IQueryHandler<GetAllMembersQuery, IEnumerable<MemberDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllMembersQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)        
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
            
        }
        public async Task<IEnumerable<MemberDto>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var Members = await _unitOfWork.Members.GetAllAsync(cancellationToken);
            var MembersDto = _mapper.Map<IEnumerable<MemberDto>>(Members);
            return MembersDto.ToList();
        }
    }
}

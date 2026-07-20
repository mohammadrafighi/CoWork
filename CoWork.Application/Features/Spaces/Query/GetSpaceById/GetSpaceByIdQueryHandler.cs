using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Space;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Spaces.Query.GetSpaceById
{
    public class GetSpaceByIdQueryHandler:IQueryHandler<GetSpaceByIdQuery,SpaceDto>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetSpaceByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SpaceDto>Handle(GetSpaceByIdQuery query,CancellationToken cancellationToken)
        {
            var space = await _unitOfWork.Spaces.GetByIdAsync(query.SpaceId, cancellationToken)
               ?? throw new InvalidOperationException("space not found");

           return _mapper.Map<SpaceDto>(space);

        }
    }
}

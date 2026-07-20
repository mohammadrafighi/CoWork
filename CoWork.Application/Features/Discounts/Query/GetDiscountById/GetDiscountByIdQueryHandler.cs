using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Discount;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Discounts.Query.GetDiscountById
{
    public class GetDiscountByIdQueryHandler:IQueryHandler<GetDiscountByIdQuery,DiscountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetDiscountByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DiscountDto>Handle(GetDiscountByIdQuery query,CancellationToken cancellationToken)
        {
            var discount = await _unitOfWork.Discounts.GetByIdAsync(query.Id, cancellationToken)
                ?? throw new InvalidOperationException("discount not found");

            var discountDto= _mapper.Map<DiscountDto>(discount);
            return discountDto;

        }
    }
}

using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Discount;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Discounts.Query.GetAllDiscounts
{
    public class GetAllDiscountsQueryHandler:IQueryHandler<GetAllDiscountsQuery,IEnumerable<DiscountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllDiscountsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }
        public async Task<IEnumerable<DiscountDto>>Handle(GetAllDiscountsQuery query,CancellationToken cancellationToken)
        {
            var discounts=await _unitOfWork.Discounts.GetAllAsync(cancellationToken);
            if (discounts == null) throw new InvalidOperationException("there is no discounts");

            var discountsDto=_mapper.Map<IEnumerable< DiscountDto>>(discounts);
            return discountsDto.ToList();
        }
    }
}

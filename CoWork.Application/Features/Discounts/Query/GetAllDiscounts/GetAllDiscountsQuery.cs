using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Discount;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Discounts.Query.GetAllDiscounts
{
    public record GetAllDiscountsQuery():IQuery<IEnumerable<DiscountDto>>
    {
    }
}

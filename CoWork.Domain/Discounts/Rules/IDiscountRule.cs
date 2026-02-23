using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Discounts.Rules
{
    public interface IDiscountRule
    {
        DiscountResult Calculate(int totalDays, decimal dailyPrice);
    }
}

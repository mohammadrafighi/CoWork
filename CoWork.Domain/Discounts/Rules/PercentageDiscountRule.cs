using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Discounts.Rules
{
    public class PercentageDiscountRule:IDiscountRule
    {
        public decimal Percentage { get; }
        public PercentageDiscountRule(decimal percentage)
        {
            if(percentage < 0||percentage > 100)throw new ArgumentOutOfRangeException(nameof(percentage));
            Percentage = percentage;
        }
        public DiscountResult Calculate(decimal totalPrice)
        {
            var amount = totalPrice * (Percentage / 100);
            return new DiscountResult(amount);
        }
    }
}

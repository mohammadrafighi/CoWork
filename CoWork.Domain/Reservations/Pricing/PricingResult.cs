using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations.Pricing
{
    public class PricingResult
    {
        public int FreeDays { get; }
        public decimal DiscountAmount {  get; }
        public PricingResult(int freeDays,decimal discountAmount)
        {
            FreeDays = freeDays;
            DiscountAmount = discountAmount;
        }
    }
}

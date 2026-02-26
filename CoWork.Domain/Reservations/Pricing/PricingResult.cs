using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations.Pricing
{
    public class PricingResult
    {
        public int FreeDays { get; }
        public decimal DiscountAmount {  get; }
        public bool HasDiscount => DiscountAmount > 0 || FreeDays > 0;
        public PricingResult(int freeDays,decimal discountAmount)
        {
            FreeDays = freeDays;
            DiscountAmount = discountAmount;
        }
        public static PricingResult Empty => new PricingResult(0, 0);
    }
}

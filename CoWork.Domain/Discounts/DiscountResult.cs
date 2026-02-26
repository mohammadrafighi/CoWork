using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Discounts
{
    public class DiscountResult
    {
        
        public decimal DiscountAmount { get; }
        public int FreeDays { get; }

        public bool HasDiscount =>
            DiscountAmount > 0 || FreeDays > 0;

        public DiscountResult(decimal discountAmount, int freeDays = 0)
        {
            DiscountAmount = discountAmount;
            FreeDays = freeDays;
        }

        public static DiscountResult Empty => new(0, 0);


    }
}

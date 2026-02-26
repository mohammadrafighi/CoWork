using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations
{
    public class AppliedDiscount
    {
      
        public string Code { get; }
        public decimal DiscountAmount { get; }
        public int FreeDays { get; }

        public AppliedDiscount(string code, decimal discountAmount, int freeDays)
        {
            Code = code;
            DiscountAmount = discountAmount;
            FreeDays = freeDays;
        }
    }
}

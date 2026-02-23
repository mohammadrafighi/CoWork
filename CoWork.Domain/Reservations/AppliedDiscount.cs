using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations
{
    public class AppliedDiscount
    {
        public string Code { get; }
        public decimal Percentage { get; }
        public decimal Amount {  get; }
        public AppliedDiscount(string code,decimal percentage,decimal amount)
        {
            Code = code;
            Percentage = percentage;
            Amount = amount;
        }
    }
}

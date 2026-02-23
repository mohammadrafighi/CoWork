using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Discounts
{
    public class DiscountResult
    {
        public int FreeDays { get; }
        public decimal Percentage { get; }
        private DiscountResult(int freeDays,decimal persentage) 
        { FreeDays = freeDays;
            Percentage = persentage;
        }
        public static DiscountResult WithPercentage(decimal persentage) => new DiscountResult(0, persentage);
        
       
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Discounts
{
    public class DiscountUsage
    {
        public Guid UserId { get;private set; }
        public DateTime UsedAt {  get;private set; }
        private DiscountUsage() { }
        public DiscountUsage(Guid userId)
        {
            UserId = userId;
            UsedAt = DateTime.UtcNow;
        }
    }
}

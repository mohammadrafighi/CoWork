using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations.Pricing
{
    public class TieredPricingPolicy:IPricingPolicy
    {
        private readonly int _requiredDays;
        private readonly int _freeDays;
        public TieredPricingPolicy(int requiredDays,int freeDays)
        {
            _requiredDays = requiredDays;
            _freeDays = freeDays;
        }
        public PricingResult ApplyPrice(IReadOnlyCollection<ReservationDay> days)
        {
            if (days.Count < _requiredDays) return new PricingResult(0, 0);
            var cheapestDaysAmount = days.OrderBy(d => d.DailyPrice).Take(_freeDays).Sum(d => d.DailyPrice);
            return new PricingResult(_freeDays, cheapestDaysAmount);

        }
    }
}

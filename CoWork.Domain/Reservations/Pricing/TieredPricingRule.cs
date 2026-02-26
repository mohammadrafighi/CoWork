using CoWork.Domain.Discounts;
using CoWork.Domain.Discounts.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations.Pricing
{
    public class TieredPricingRule
    {
        public int RequiredDays;
        public int FreeDays;

        public TieredPricingRule(int requiredDays, int freeDays)
        {
            if (requiredDays <= 0) throw new ArgumentOutOfRangeException(nameof(requiredDays));
            if (freeDays <= 0) throw new ArgumentOutOfRangeException(nameof(freeDays));

            RequiredDays = requiredDays;
            FreeDays = freeDays;
        }
        public PricingResult Apply(IReadOnlyCollection<ReservationDay> days)
        {
            if (days.Count < RequiredDays)
                return PricingResult.Empty;

            var cheapestAmount = days
                .OrderBy(d => d.DailyPrice)
                .Take(FreeDays)
                .Sum(d => d.DailyPrice);

            return new PricingResult(FreeDays,cheapestAmount);
        }
    }
}

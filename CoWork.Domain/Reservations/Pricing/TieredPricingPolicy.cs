using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations.Pricing
{
    public class TieredPricingPolicy:IPricingPolicy
    {
        private readonly List<TieredPricingRule> _rules;

        public TieredPricingPolicy(IEnumerable<TieredPricingRule> rules)
        {
            _rules = rules.ToList();
        }

        public PricingResult ApplyPrice(IReadOnlyCollection<ReservationDay> days)
        {
            PricingResult bestResult = PricingResult.Empty;

            foreach (var rule in _rules)
            {
                var result = rule.Apply(days);
                if (result.DiscountAmount > bestResult.DiscountAmount)
                    bestResult = result;
            }

            return bestResult;

           
        }
    }
}

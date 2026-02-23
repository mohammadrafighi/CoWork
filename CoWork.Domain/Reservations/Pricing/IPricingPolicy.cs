using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations.Pricing
{
    public interface IPricingPolicy
    {
        PricingResult ApplyPrice(IReadOnlyCollection<ReservationDay> days);
    }
}

using CoWork.Domain.Common;
using CoWork.Domain.Discounts;
using CoWork.Domain.Reservations.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations
{
    public class Reservation : AggregateRoot<Guid>
    {
        public string ReservationCode { get; private set; }
        public Guid UserId { get; private set; }
        /// <summary>
        /// Maybe we want to add a space
        /// </summary>
        public Guid SpaceId { get; private set; }
        public ReservationStatus Status { get; private set; }
        private readonly List<ReservationDay> _days = new();
        public IReadOnlyCollection<ReservationDay> Days => _days.AsReadOnly();
        public decimal TotalPrice { get; private set; }
        public decimal FinalPrice { get; private set; }
        public AppliedDiscount? AppliedDiscount { get; private set; }
        private Reservation() { }
        public Reservation(Guid userId, Guid spaceId, string reservationCode)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            SpaceId = spaceId;
            ReservationCode = reservationCode;
            Status = ReservationStatus.Draft;

        }
        public void AddDay(DateOnly date, decimal dailyPrice)
        {
            if (Status != ReservationStatus.Draft) throw new InvalidOperationException("can not modify reservation");
            if (_days.Any(d => d.Date == date)) throw new InvalidOperationException("duplicate day");
            _days.Add(new ReservationDay(date, dailyPrice));
            RecalculateTotal();
        }
        public void RemoveDay(DateOnly date, decimal dailyPrice)
        {
            if (Status != ReservationStatus.Draft) throw new InvalidOperationException("can not modify this reservation");
            var reservationDay=_days.FirstOrDefault(d => d.Date==date);
            if (reservationDay == null) throw new ArgumentNullException(nameof(reservationDay));
            _days.Remove(reservationDay);
            RecalculateTotal();
        }
        public void ApplyPricingPolicy(TieredPricingPolicy policy)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));

            var result = policy.ApplyPrice(Days); 
            ApplyDiscount("TieredPricing", new DiscountResult(result.DiscountAmount, result.FreeDays));

        }
        private void RecalculateTotal()
        {
            TotalPrice = _days.Sum(d => d.DailyPrice);
            FinalPrice = TotalPrice;

            if (AppliedDiscount != null)
            {
                FinalPrice -= AppliedDiscount.DiscountAmount;
                if (FinalPrice < 0)
                    FinalPrice = 0;
            }
        }
        public void ApplyDiscount(string code, DiscountResult result)
        {
            if (IsPaid) throw new InvalidOperationException("can not apply this to a paid reservation");
            if (AppliedDiscount != null) throw new InvalidOperationException("it was applied before");
            if (result is null)
                throw new ArgumentNullException(nameof(result));

            if (!result.HasDiscount)
                return;

            AppliedDiscount = new AppliedDiscount(
                code,
                result.DiscountAmount,
                result.FreeDays
            );

            FinalPrice -= result.DiscountAmount;

            if (FinalPrice < 0)
                FinalPrice = 0;
        }
        public bool IsPaid { get; private set; }
        public void MarkAsPaid()
        {
           
            if (IsPaid)
                throw new InvalidOperationException("Reservation already paid");
            if (FinalPrice < 0)
                throw new InvalidOperationException("Invalid final price");
            Status = ReservationStatus.Paid;
            IsPaid = true;
        }
    }
}

using CoWork.Domain.Common;
using CoWork.Domain.Reservations.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations
{
    public class Reservation : AggregateRoot<Guid>
    {
        
        public Guid UserId { get; private set; }
        public Guid SpaceId { get; private set; }
        public ReservationStatus Status { get; private set; }
        private readonly List<ReservationDay> _days = new();
        public IReadOnlyCollection<ReservationDay> Days => _days.AsReadOnly();
        public decimal TotalPrice { get; private set; }
        public decimal FinalPrice { get; private set; }
        public AppliedDiscount? AppliedDiscount { get; private set; }
        private Reservation() { }
        public Reservation(Guid userId, Guid spaceId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            SpaceId = spaceId;
            Status = ReservationStatus.Draft;
        }
        public void AddDay(DateOnly date, decimal dailyPrice)
        {
            if (Status != ReservationStatus.Draft) throw new InvalidOperationException("can not modify reservation");
            if (_days.Any(d => d.Date == date)) throw new InvalidOperationException("duplicate day");
            _days.Add(new ReservationDay(date, dailyPrice));
        }
        public void ApplyPricingPolicy(IPricingPolicy policy)
        {
            var result = policy.ApplyPrice(_days);
            TotalPrice = _days.Sum(d => d.DailyPrice);
            FinalPrice = TotalPrice - result.DiscountAmount;
        }
        public void ApplyPercentageDiscount(string code, decimal percentage)
        {
            if (percentage <= 0 || percentage > 100) throw new ArgumentOutOfRangeException(nameof(percentage));
            var amount = FinalPrice * (percentage / 100);
            AppliedDiscount = new AppliedDiscount(code, percentage, amount);
            FinalPrice -= amount;
        }
        public void MarkAsPaid()
        {
            if (FinalPrice < 0) FinalPrice = 0;
            Status = ReservationStatus.Paid;
        }
    }
}

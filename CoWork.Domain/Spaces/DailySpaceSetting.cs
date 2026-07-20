using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Spaces
{
    public class DailySpaceSetting
    {
        public DateOnly Date { get; private set; }
        public int? CapacityOverride { get; private set; }
        public decimal? PriceOverride { get; private set; }
        public bool IsClosed { get; private set; }
        public int ReservedCount { get; private set; }
        private DailySpaceSetting() { }
        public DailySpaceSetting(DateOnly date)
        {
            Date = date;
            ReservedCount = 0;
            IsClosed = false;
        }

        public int GetEffectiveCapacity(int baseCapacity)=> CapacityOverride ?? baseCapacity;

        public decimal GetEffectivePrice(decimal basePrice)=> PriceOverride ?? basePrice;

        public bool HasAvailableCapacity(int baseCapacity)=> ReservedCount < GetEffectiveCapacity(baseCapacity);

        public void ReserveSeat(int baseCapacity)
        {
            if (IsClosed)throw new InvalidOperationException("Space is closed on this date.");
            if (!HasAvailableCapacity(baseCapacity))throw new InvalidOperationException("No capacity available for this date.");

            ReservedCount++;
        }
        public void CancelSeat()
        {
            ReservedCount--;
        }
        public void ChangeCapacity(int capacity)
        {
            if (capacity < ReservedCount)throw new InvalidOperationException("Capacity cannot be less than reserved count.");

            CapacityOverride = capacity;
        }

        public void ChangePrice(decimal price)
        {
            if (price < 0)throw new InvalidOperationException("Price must be positive.");

            PriceOverride = price;
        }

        public void Close()
        {
            IsClosed = true;
        }
    }
}

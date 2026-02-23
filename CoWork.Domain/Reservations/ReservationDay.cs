using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations
{
    public class ReservationDay
    {
        public DateOnly Date { get; private set; }
        public decimal DailyPrice {  get; private set; }
        private ReservationDay() { }
        public ReservationDay(DateOnly date,decimal dailyPrice)
        {
            if(dailyPrice < 0)throw new ArgumentOutOfRangeException(nameof(dailyPrice));
            Date=date;
            DailyPrice=dailyPrice;
        }
    }
}

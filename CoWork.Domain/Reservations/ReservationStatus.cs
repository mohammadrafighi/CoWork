using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Reservations
{
    public enum ReservationStatus
    {
        Draft=1,
        Paid=2,
        Cancelled=3,
        PendingToPay=4
    }
}

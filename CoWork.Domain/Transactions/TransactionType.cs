using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Transactions
{
    public enum TransactionType
    {
        ChargeWalletToUpManual = 1,
        ChargeWalletToUpGateWay = 2,
        ChargeWalletToUpAdmin = 3 ,

        Reservation = 4 , 
        CancelReservation = 5 ,

    }
}

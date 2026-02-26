using CoWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace CoWork.Domain.Transactions
{
    public class Transaction : BaseEntity<Guid>
    {
        protected Transaction(){ }
         
        public TransactionStatus TransactionStatus { get; private set; }   
        public TransactionType TransactionType { get; private set; }   
        
        public Guid ?DebtorWalletAccountId { get; private set; }
        public Guid CreditorWalletAccountId { get; private set; }
        public string? ReceiptImageUrl { get; private set; }

        public Guid ?ReserveId { get; private set;}
        public DateTime CreatedAt { get; private set; }
        public decimal Amount { get; private set; }

        private Transaction(TransactionStatus transactionStatus, TransactionType transactionType,
            Guid? debtorWalletAccountId,Guid creditorWalletAccountId , Guid ?reserveId ,decimal amount, string ?receiptImageUrl)
        {
            TransactionStatus = transactionStatus;  
            TransactionType = transactionType;
            DebtorWalletAccountId = debtorWalletAccountId;
            CreditorWalletAccountId = creditorWalletAccountId;  
            ReserveId = reserveId;
            Amount = amount;
            ReceiptImageUrl = receiptImageUrl;
            CreatedAt = DateTime.UtcNow;    

        }
        public static Transaction CreateReservePayment(
            Guid debtorWalletAccountId, Guid creditorWalletAccountId, Guid reserveId, decimal amount)
        {
            return new Transaction
                (TransactionStatus.Succeed, TransactionType.Reservation , debtorWalletAccountId, creditorWalletAccountId, reserveId, amount ,null );
        }
        public static Transaction CreateReserveRefund(
            Guid debtorWalletAccountId, Guid creditorWalletAccountId, Guid reserveId, decimal amount)
        {
            return new Transaction
                (TransactionStatus.Succeed, TransactionType.CancelReservation, debtorWalletAccountId, creditorWalletAccountId, reserveId, amount, null);
        }
        public static Transaction CreateWalletUpManual(
             Guid creditorWalletAccountId, decimal amount , string receiptImageUrl)
        {
            return new Transaction
                (TransactionStatus.Pending, TransactionType.ChargeWalletToUpManual ,null , creditorWalletAccountId, null, amount ,receiptImageUrl);
        }
        public static Transaction CreateWalletUpAdmin (
        Guid UserWalletAccountId, decimal amount)
        {
            return new Transaction
                (TransactionStatus.Succeed, TransactionType.ChargeWalletToUpAdmin, null, UserWalletAccountId, null, amount, null );
        }
        //ToDo:
        public static Transaction CreateWalletUpGateWay()
        {
            throw new NotImplementedException();    
        }
        public void MarkAsSucceeded()
        {
            if (TransactionStatus != TransactionStatus.Pending)
                throw new InvalidOperationException("Only pending transactions can change status.");

            TransactionStatus = TransactionStatus.Succeed;
        }

        public void MarkAsFailed()
        {
            if (TransactionStatus != TransactionStatus.Pending)
                throw new InvalidOperationException("Only pending transactions can change status.");

            TransactionStatus = TransactionStatus.Failed;
        }



    }
}

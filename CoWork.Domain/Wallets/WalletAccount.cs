using CoWork.Domain.Common;
using CoWork.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace CoWork.Domain.Wallets
{
    public class WalletAccount : BaseEntity<Guid>
    {
        public Guid? MemberId { get; private set; }
        public WalletOwnerType OwnerType { get; private set; }
        public decimal Balance { get; private set; }

        protected WalletAccount(){}
        private WalletAccount(Guid? memberId,WalletOwnerType walletOwnerType)
        {
            MemberId = memberId;
            OwnerType = walletOwnerType;    
            Balance = 0;     
        }
        public static WalletAccount CreateWalletAccount(Guid memberId, WalletOwnerType walletOwnerType)
        {
            if(walletOwnerType == WalletOwnerType.User) { 
            return new WalletAccount(memberId, walletOwnerType);
            }
            else if(walletOwnerType == WalletOwnerType.Compony)
            {
                return new WalletAccount(null , walletOwnerType);   
            }else
            {
                throw new Exception("Unhandeled");
            }
        }
        public Transaction IncreaseBalanceByAdmin(decimal amount)
        {
            var transaction = Transaction.CreateWalletUpAdmin(Id, amount);
            Balance = Balance + amount;
            return transaction;
        }
        public Transaction IncreaseBalanceManual(Guid creditorWalletAccountId, decimal amount, string receiptImageUrl)
        {
            var transaction = Transaction.CreateWalletUpManual(creditorWalletAccountId, amount, receiptImageUrl);
            Balance = Balance + amount;
            return transaction;
        }
        public Transaction ReservePayment(Guid creditorWalletAccountId, Guid reserveId, decimal amount)
        {
            if (Balance < amount)
            {
                throw new ArgumentOutOfRangeException("Please Charge Your Wallet");
            }
            var transaction = Transaction.CreateReservePayment(Id, creditorWalletAccountId, reserveId, amount);
                return transaction;  
        }
        public Transaction ReserveRefund(Guid SystemWalletAccountId, Guid reserveId, decimal amount)
        {
            if (Balance < amount)
            {
                throw new ArgumentOutOfRangeException("Please Charge Your Wallet");
            }
            var transaction = Transaction.CreateReserveRefund(SystemWalletAccountId, Id, reserveId, amount);
            return transaction;
        }


        //ToDo:
        public Guid IncreaseBalanceByGateWay()
        {

            throw new NotImplementedException();

        }
    }
}

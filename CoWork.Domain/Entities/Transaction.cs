using CoWork.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Entities
{
    public class Transaction:BaseEntity<Guid>
    {
        public decimal Amount {  get; set; }
        public Guid WalletAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

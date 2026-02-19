using CoWork.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Entities
{
    public class WalletAccount:BaseEntity<Guid>
    {
        public Guid MemberId { get; set; }
        public decimal Balance {  get; set; }

    }
}

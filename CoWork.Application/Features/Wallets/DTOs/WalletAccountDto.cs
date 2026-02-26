using CoWork.Domain.Wallets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.DTOs
{
    public class WalletAccountDto
    {

        public Guid Id {  get; set; }
        public Guid? MemberId { get; set; }
        public WalletOwnerType OwnerType { get; set; }
        public decimal Balance { get; set; }
    }
}

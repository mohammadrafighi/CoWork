using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Features.Wallets.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Query.GetAllWalletQuery
{
    public record GetAllWalletQuery():IQuery<IEnumerable<WalletAccountDto>>
    {
    }
}

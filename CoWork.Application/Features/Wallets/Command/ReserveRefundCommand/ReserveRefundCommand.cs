using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.ReserveRefundCommand
{
    public record ReserveRefundCommand(Guid WalletId,Guid SystemWalletAccountId, Guid reserveId, decimal amount) :ICommand<Guid>
    {
    }
}

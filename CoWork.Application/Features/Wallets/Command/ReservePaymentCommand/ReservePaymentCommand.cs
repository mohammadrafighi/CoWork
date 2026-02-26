using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.ReservePaymentCommand
{
    public record ReservePaymentCommand(Guid ComponyWalletId
     ,Guid WalletId, Guid reserveId) :ICommand<Guid>
    {
    }
}

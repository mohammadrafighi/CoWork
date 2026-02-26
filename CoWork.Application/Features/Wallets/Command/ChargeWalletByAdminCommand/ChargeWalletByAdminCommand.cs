using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.ChargeWalletByAdminCommand
{
    public record ChargeWalletByAdminCommand(Guid WalletId,decimal amount) : ICommand<Guid>
    {
    }
}

using CoWork.Application.Abstraction.CQRS;
using CoWork.Domain.Wallets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.CreateWalletCommand
{
    public record CreateWalletAccountCommand(WalletOwnerType WalletOwnerType,Guid MemberId):ICommand<Guid>
    {
    }
}

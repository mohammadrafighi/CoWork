using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using CoWork.Application.Interfaces.MinIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.ChargeWalletByManualCommand
{
    public record ChargeWalletManualCommand(
        Guid creditorWalletAccountId, decimal amount ,
        Stream fileStream, string fileName, string contentType, long fileSize) : ICommand<Guid>
    {

    }
}

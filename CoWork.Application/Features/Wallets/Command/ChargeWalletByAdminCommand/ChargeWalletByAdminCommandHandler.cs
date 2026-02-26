using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.ChargeWalletByAdminCommand
{
    public class ChargeWalletByAdminCommandHandler : ICommandHandler<ChargeWalletByAdminCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChargeWalletByAdminCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<Guid> Handle(ChargeWalletByAdminCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _unitOfWork.WalletAccounts.GetByIdAsync(request.WalletId, cancellationToken);
            var transaction = wallet.IncreaseBalanceByAdmin(request.amount);
            await _unitOfWork.Transactions.AddAsync(transaction, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);  
            return transaction.Id;   

        }
    }
}

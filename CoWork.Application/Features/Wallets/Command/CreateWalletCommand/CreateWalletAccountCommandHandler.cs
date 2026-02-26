using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using CoWork.Domain.Wallets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.CreateWalletCommand
{
    public class CreateWalletAccountCommandHandler : ICommandHandler<CreateWalletAccountCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateWalletAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<Guid> Handle(CreateWalletAccountCommand request, CancellationToken cancellationToken)
        {
            var wallet = WalletAccount.CreateWalletAccount(request.MemberId, request.WalletOwnerType);
            await _unitOfWork.WalletAccounts.AddAsync(wallet,cancellationToken);
            await _unitOfWork.SaveChangesAsync( cancellationToken); 
            return wallet.Id;  
        }
    }
}

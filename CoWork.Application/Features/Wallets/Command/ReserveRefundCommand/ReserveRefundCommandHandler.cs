using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.ReserveRefundCommand
{
    public class ReserveRefundCommandHandler : ICommandHandler<ReserveRefundCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReserveRefundCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<Guid> Handle(ReserveRefundCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _unitOfWork.WalletAccounts.GetByIdAsync(request.WalletId,cancellationToken);
            var reserve= await _unitOfWork.Reservations.GetByIdAsync(request.reserveId,cancellationToken);
            //TodO:
            //Reserve.cansel
            var transaction = wallet.ReserveRefund(request.SystemWalletAccountId,request.reserveId , request.amount);
            await _unitOfWork.Transactions.AddAsync(transaction,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return transaction.Id;
        }
    }
}

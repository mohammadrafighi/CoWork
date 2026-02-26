using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.ReservePaymentCommand
{
    public class ReservePaymentCommandHandler : ICommandHandler<ReservePaymentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservePaymentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(ReservePaymentCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _unitOfWork.WalletAccounts.GetByIdAsync(request.WalletId,cancellationToken);
            var reserve = await _unitOfWork.Reservations.GetByIdAsync(request.reserveId,cancellationToken);
            var transaction =wallet.ReservePayment(request.ComponyWalletId, request.reserveId, reserve.FinalPrice);
            await _unitOfWork.Transactions.AddAsync(transaction, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return transaction.Id;   
        }
    }
}

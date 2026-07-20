using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Command.PayReservation
{
    public class PayReservationCommandHandler/*:ICommandHandler<PayReservationCommand,Guid>*/
    {
        //private readonly IUnitOfWork _unitOfWork;
        //public PayReservationCommandHandler(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        //public async Task<Guid> Handle(PayReservationCommand command,CancellationToken cancellationToken)
        //{
        //    var reservation =await _unitOfWork.Reservations.GetByIdAsync(command.reservationId, cancellationToken)
        //        ?? throw new InvalidOperationException("reservation not found");

        //    if (reservation.IsPaid) throw new InvalidOperationException("reservation ended");
        //    var wallet = await _unitOfWork.WalletAccounts
        //   .QuerySingleAsync(
        //       w => w.MemberId == reservation.UserId,
        //       w => w,
        //       cancellationToken: cancellationToken
        //   )
        //   ?? throw new InvalidOperationException("wallet not found");

        //    wallet.ReservePayment()
        //} 
    }
}

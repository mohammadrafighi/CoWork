using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Command.RemoveDiscountFromReservation
{
    public class RemoveDiscountFromReservationCommandHandler : ICommandHandler<RemoveDiscountFromReservationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoveDiscountFromReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(RemoveDiscountFromReservationCommand command, CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(command.reservationId, cancellationToken)
                ?? throw new InvalidOperationException("reservation not found");

            reservation.RemoveDiscount(command.discountCode);
            await _unitOfWork.SaveChangesAsync();
            return reservation.Id;

        }
    }
}

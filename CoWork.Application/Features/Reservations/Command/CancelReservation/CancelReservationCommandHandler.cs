using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Command.CancelReservation
{
    public class CancelReservationCommandHandler:ICommandHandler<CancelReservationCommand,Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CancelReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid>Handle(CancelReservationCommand command,CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(command.reservationId, cancellationToken)
                ?? throw new InvalidOperationException("reservation not found");

            var space=await _unitOfWork.Spaces.GetByIdAsync(reservation.SpaceId, cancellationToken);

            reservation.CancelReservation();
            foreach(var day in reservation.Days)
            {
                space.Cancel(day.Date);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return reservation.Id;


        }
    }
}

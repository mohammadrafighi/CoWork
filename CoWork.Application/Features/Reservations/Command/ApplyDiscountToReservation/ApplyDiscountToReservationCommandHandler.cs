using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Command.ApplyDiscountToReservation
{
   public class ApplyDiscountToReservationCommandHandler:ICommandHandler<ApplyDiscountToReservationCommand,Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplyDiscountToReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public async Task<Guid> Handle(ApplyDiscountToReservationCommand command,CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(command.reservationId, cancellationToken)
                ?? throw new InvalidOperationException("reservation not found");

           
            var discount = await _unitOfWork.Discounts
                   .QuerySingleAsync(d => d.Code == command.discountCode, d => d,
                       cancellationToken: cancellationToken
                   )
                   ?? throw new InvalidOperationException("Discount not found");

            if (!discount.CanBeUsedBy(reservation.UserId))
                throw new InvalidOperationException("Discount not allowed");
            
            
            var discountResult = discount.Apply(reservation.UserId, reservation.TotalPrice);
            reservation.ApplyDiscount(discount.Code, discountResult);

            //await _unitOfWork.Reservations.AddAsync(reservation, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return reservation.Id;



        }
    }
}

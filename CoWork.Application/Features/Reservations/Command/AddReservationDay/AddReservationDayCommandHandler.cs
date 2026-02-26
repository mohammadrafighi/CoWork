using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using CoWork.Domain.Reservations.Pricing;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CoWork.Application.Features.Reservations.Command.AddReservationDay
{
    public class AddReservationDayCommandHandler: ICommandHandler<AddReservationDayCommand,Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddReservationDayCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            AddReservationDayCommand command,
            CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.Reservations
                .GetByIdAsync(command.ReservationId, cancellationToken)
                ?? throw new InvalidOperationException("Reservation not found");

            if (reservation.IsPaid)
                throw new InvalidOperationException("Cannot modify a paid reservation");

            var space = await _unitOfWork.Spaces
                .GetByIdAsync(reservation.SpaceId, cancellationToken)
                ?? throw new InvalidOperationException("Space not found");

            var price = space.GetPriceForADay(command.Day);

            reservation.AddDay(command.Day, price);

           
            var pricingPolicy = new TieredPricingPolicy(new[]
            {
            new TieredPricingRule(20, 5),
            new TieredPricingRule(10, 2)
        });

            reservation.ApplyPricingPolicy(pricingPolicy);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            ///in mediateR when we dont have result
            //return Unit.Value;
            return reservation.Id;
        }
    }
}

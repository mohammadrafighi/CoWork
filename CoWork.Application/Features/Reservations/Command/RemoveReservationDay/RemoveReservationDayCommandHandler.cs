using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using CoWork.Domain.Reservations.Pricing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Command.RemoveReservationDay
{
    public class RemoveReservationDayCommandHandler:ICommandHandler<RemoveReservationDayCommand,Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoveReservationDayCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(RemoveReservationDayCommand command,CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.Reservations
                .GetByIdAsync(command.reservationId, cancellationToken)
                ?? throw new InvalidOperationException("reservation not found");

            if (reservation.IsPaid) throw new InvalidOperationException("can not modify this reservation");

            var space = await _unitOfWork.Spaces
                .GetByIdAsync(reservation.SpaceId, cancellationToken)
                ?? throw new InvalidOperationException("space not found");
            var price = space.GetPriceForADay(command.day);
            reservation.RemoveDay(command.day,price);

            var pricingPolicy = new TieredPricingPolicy(new[]
            {
                new TieredPricingRule(20,5),
                new TieredPricingRule(10,2)
            });
            reservation.ApplyPricingPolicy(pricingPolicy);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return reservation.Id;
        }
    }
}

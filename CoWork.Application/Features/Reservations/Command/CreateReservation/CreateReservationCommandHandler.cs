using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using CoWork.Domain.Discounts;
using CoWork.Domain.Discounts.Rules;
using CoWork.Domain.Reservations;
using CoWork.Domain.Reservations.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Command.CreateReservation
{
    public class CreateReservationCommandHandler : ICommandHandler<CreateReservationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationCodeGenerator _reservationCodeGenerator;
        public CreateReservationCommandHandler(IUnitOfWork unitOfWork, IReservationCodeGenerator reservationCodeGenerator)
        {
            _unitOfWork = unitOfWork;
            _reservationCodeGenerator = reservationCodeGenerator;
        }
        public async Task<Guid> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
        {
            var space = await _unitOfWork.Spaces.GetByIdAsync(command.SpaceId, cancellationToken)
                ?? throw new InvalidOperationException("space not found");

            var reservationcode = await _reservationCodeGenerator.GenerateAsync(cancellationToken);

            var reservation = new Reservation(command.UserId, command.SpaceId, reservationcode);
            foreach (var day in command.Days)
            {
                var price = space.GetPriceForADay(day);
                reservation.AddDay(day, price);
            }

            var pricingPolicy = new TieredPricingPolicy(new[]
       {
            new TieredPricingRule(20, 5),
            new TieredPricingRule(10, 2)
        });

            var tieredResult = pricingPolicy.ApplyPrice(reservation.Days);
            reservation.ApplyDiscount("TieredRule", new DiscountResult(tieredResult.DiscountAmount, tieredResult.FreeDays));

            //delete this
            //if (!string.IsNullOrWhiteSpace(command.DiscountCode))
            //{
            //    var discount = await _unitOfWork.Discounts
            //        .QuerySingleAsync(d => d.Code == command.DiscountCode, d => d,
            //            cancellationToken: cancellationToken
            //        )
            //        ?? throw new InvalidOperationException("Discount not found");

            //    if (!discount.CanBeUsedBy(command.UserId))
            //        throw new InvalidOperationException("Discount not allowed");

            //    var discountResult = discount.Apply(command.UserId, reservation.TotalPrice);
            //    reservation.ApplyDiscount(discount.Code, discountResult);
            //}
            await _unitOfWork.Reservations.AddAsync(reservation, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return reservation.Id;
        }
    }

}


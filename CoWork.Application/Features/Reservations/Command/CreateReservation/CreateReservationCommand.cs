using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CoWork.Application.Features.Reservations.Command.CreateReservation
{
    public record CreateReservationCommand
        (Guid UserId,Guid SpaceId,IReadOnlyCollection<DateOnly>Days,string? DiscountCode):ICommand<Guid>
    {

    }
}

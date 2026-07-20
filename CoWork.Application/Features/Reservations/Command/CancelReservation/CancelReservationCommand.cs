using System;
using System.Collections.Generic;
using System.Text;
using CoWork.Application.Abstraction.CQRS;
using System.Windows.Input;

namespace CoWork.Application.Features.Reservations.Command.CancelReservation
{
    public record CancelReservationCommand(Guid reservationId):ICommand<Guid>
    {
    }
}

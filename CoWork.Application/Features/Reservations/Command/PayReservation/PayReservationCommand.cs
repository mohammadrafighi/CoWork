using System;
using System.Collections.Generic;
using System.Text;
using CoWork.Application.Abstraction.CQRS;
using System.Windows.Input;


namespace CoWork.Application.Features.Reservations.Command.PayReservation
{
    public record PayReservationCommand(Guid reservationId):ICommand<Guid>
    {
    }
}

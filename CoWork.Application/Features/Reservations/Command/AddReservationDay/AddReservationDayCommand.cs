using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Command.AddReservationDay
{
    public record AddReservationDayCommand(Guid ReservationId,DateOnly Day) : ICommand<Guid>
    {

    }
}

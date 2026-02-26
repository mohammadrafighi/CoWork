using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CoWork.Application.Abstraction.CQRS;
using ICommand = CoWork.Application.Abstraction.CQRS.ICommand;

namespace CoWork.Application.Features.Reservations.Command.RemoveReservationDay
{
    public record RemoveReservationDayCommand(Guid reservationId,DateOnly day): ICommand<Guid>
    {
    }
}

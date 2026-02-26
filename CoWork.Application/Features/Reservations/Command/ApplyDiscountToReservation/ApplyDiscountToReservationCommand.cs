using CoWork.Application.Abstraction.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CoWork.Application.Features.Reservations.Command.ApplyDiscountToReservation
{
    public record ApplyDiscountToReservationCommand : ICommand<Guid>
    {
        public Guid ReservationId {  get; set; }
        public string DiscountCode { get; set; } 
    }
}

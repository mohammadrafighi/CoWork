using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Query.GetAllReservations
{
    public record GetAllReservationsQuery():IQuery<IEnumerable<ReservationDto>>
    {
    }
}

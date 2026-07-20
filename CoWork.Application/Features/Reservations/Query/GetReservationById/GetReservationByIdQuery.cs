using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Query.GetReservationById
{
    public record GetReservationByIdQuery(Guid ReservataionId):IQuery<ReservationDto>
    {
    }
}

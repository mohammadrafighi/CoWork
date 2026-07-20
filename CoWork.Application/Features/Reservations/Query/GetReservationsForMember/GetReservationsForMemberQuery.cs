using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Query.GetReservationsForMember
{
    public record GetReservationsForMemberQuery(Guid MemberId):IQuery<IEnumerable<ReservationDto>>
    {
    }
}

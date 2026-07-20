using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Reservation;
using CoWork.Application.Interfaces;
using CoWork.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Query.GetReservationsForMember
{
    public class GetReservationsForMemberQueryHandler:IQueryHandler<GetReservationsForMemberQuery,IEnumerable<ReservationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetReservationsForMemberQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }
        public async Task<IEnumerable<ReservationDto>>Handle(GetReservationsForMemberQuery query,CancellationToken cancellationToken)
        {
            var reservations = await _unitOfWork.Reservations
                .QueryAsync<Reservation>(
                                         predicate: x => x.UserId == query.MemberId
                                                        );
            if (reservations == null)
                throw new InvalidOperationException("reservations for this member Not found");
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);

        }
    }
}

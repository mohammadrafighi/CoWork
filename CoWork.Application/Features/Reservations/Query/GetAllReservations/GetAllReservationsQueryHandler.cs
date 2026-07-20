using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Reservation;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Query.GetAllReservations
{
    public class GetAllReservationsQueryHandler:IQueryHandler<GetAllReservationsQuery,IEnumerable<ReservationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllReservationsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }
        //todo search for better way
        public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsQuery query,CancellationToken cancellationToken)
        {
            var reservations=await _unitOfWork.Reservations.GetAllAsync(cancellationToken);
            if (reservations == null) throw new Exception("there is no reservations");

            var reservationsDto=_mapper.Map<IEnumerable<ReservationDto>>(reservations);
            return reservationsDto.ToList();

        }

    }
}

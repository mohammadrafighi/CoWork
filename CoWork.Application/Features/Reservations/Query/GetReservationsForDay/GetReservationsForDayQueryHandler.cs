using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Reservation;
using CoWork.Application.Interfaces;
using CoWork.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Query.GetReservationsForDay
{
    public class GetReservationsForDayQueryHandler:IQueryHandler<GetReservationsForDayQuery, IEnumerable<ReservationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetReservationsForDayQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //its not correct
        //todo change it
        public async Task<IEnumerable<ReservationDto>>Handle(GetReservationsForDayQuery query,CancellationToken cancellationToken)
        {

            var reservations = await _unitOfWork.Reservations.GetAllAsync(cancellationToken);

            if (reservations == null)
                throw new InvalidOperationException("reservations for this member Not found");

            
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }
    }
}

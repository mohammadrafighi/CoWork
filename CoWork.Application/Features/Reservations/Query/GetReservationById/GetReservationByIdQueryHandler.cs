using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Reservation;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Reservations.Query.GetReservationById
{
    public class GetReservationByIdQueryHandler:IQueryHandler<GetReservationByIdQuery,ReservationDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetReservationByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }
        public async Task<ReservationDto>Handle(GetReservationByIdQuery request,CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(request.ReservataionId, cancellationToken)
                ?? throw new InvalidOperationException("reservation not found");

            var reservationDto=_mapper.Map<ReservationDto>(reservation);
            return reservationDto;

        }
    }
}

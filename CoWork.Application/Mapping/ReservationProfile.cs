using AutoMapper;
using CoWork.Application.DTOs.Reservation;
using CoWork.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Mapping
{
    public class ReservationProfile:Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation,ReservationDto>();

            
        }
    }
}

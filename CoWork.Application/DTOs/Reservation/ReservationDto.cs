using CoWork.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.DTOs.Reservation
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? SpaceId { get; set; }
        public string ReservationCode {  get; set; }
        public ReservationStatus Status { get; set; }
        public decimal FinalPrice {  get; set; }
        //todo search


        //public List<ReservationDay>ReservationDays { get; set; }=new List<ReservationDay>();
        


    }
}

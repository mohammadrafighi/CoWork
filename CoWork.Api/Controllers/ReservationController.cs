using CoWork.Application.DTOs.Reservation;
using CoWork.Application.Features.Reservations.Command.AddReservationDay;
using CoWork.Application.Features.Reservations.Command.ApplyDiscountToReservation;
using CoWork.Application.Features.Reservations.Command.CancelReservation;
using CoWork.Application.Features.Reservations.Command.CreateReservation;
using CoWork.Application.Features.Reservations.Command.RemoveDiscountFromReservation;
using CoWork.Application.Features.Reservations.Command.RemoveReservationDay;
using CoWork.Application.Features.Reservations.Query.GetAllReservations;
using CoWork.Application.Features.Reservations.Query.GetReservationById;
using CoWork.Application.Features.Reservations.Query.GetReservationsForMember;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations(CancellationToken cancellationToken)
        {
            var reservations = await _mediator.Send(new GetAllReservationsQuery());
            return Ok(reservations);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ReservationDto>> GetReservations(Guid id, CancellationToken cancellationToken)
        {
            var reservation = await _mediator.Send(new GetReservationByIdQuery(id));
            return Ok(reservation);
        }

        [HttpGet]
        public async Task<ActionResult<ReservationDto>> GetReservationsForMember(Guid id, CancellationToken cancellationToken) 
        {
            var reservation = await _mediator.Send(new GetReservationsForMemberQuery(id));
            return Ok(reservation);
        }
        [HttpPost]

    //to do change
        public async Task<ActionResult<Guid>>PostReservations(CreateReservationCommand command,CancellationToken cancellationToken)
        {
            var reservation=await _mediator.Send(command);
            return CreatedAtAction("CreateReservation", new {},reservation);
        }
        [HttpPut]
        public async Task<ActionResult<Guid>>AddDay(AddReservationDayCommand command,CancellationToken cancellationToken)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> RemoveDay(RemoveReservationDayCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> AddDiscount(ApplyDiscountToReservationCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> RemoveDiscount(RemoveDiscountFromReservationCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> CancelReservations(CancelReservationCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

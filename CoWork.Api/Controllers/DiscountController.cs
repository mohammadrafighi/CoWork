using CoWork.Application.DTOs.Discount;
using CoWork.Application.Features.Discounts.Command.CreateDiscount;
using CoWork.Application.Features.Discounts.Command.DeleteDiscount;
using CoWork.Application.Features.Discounts.Query.GetAllDiscounts;
using CoWork.Application.Features.Discounts.Query.GetDiscountById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<DiscountDto>>GetDiscounts(Guid Id,CancellationToken cancellationToken)
        {
            var discount=await _mediator.Send(new GetDiscountByIdQuery(Id));
            return Ok(discount);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountDto>>>GetDiscounts(CancellationToken cancellationToken)
        {
            var discounts = await _mediator.Send(new GetAllDiscountsQuery());
            return Ok(discounts);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>>PostDiscounts(CreateDiscountCommand command,CancellationToken cancellationToken)
        {
            var discount = await _mediator.Send(command);
            return CreatedAtAction("CreateDiscount", new {}, discount);
        }
        [HttpDelete]
        public async Task<ActionResult>DeleteDiscounts(Guid Id,CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteDiscountCommand(Id));
            return Ok();
        }
    }
}

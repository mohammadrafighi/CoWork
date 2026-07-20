using CoWork.Application.DTOs.Space;
using CoWork.Application.Features.Spaces.Command.CreateSpace;
using CoWork.Application.Features.Spaces.Command.DeleteSpace;
using CoWork.Application.Features.Spaces.Command.UpdateSpaceBase;
using CoWork.Application.Features.Spaces.Query.GetSpaceById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpaceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<SpaceDto>>GetSpaces(Guid Id,CancellationToken cancellationToken)
        {
            var space= await _mediator.Send(new GetSpaceByIdQuery(Id));
            return Ok(space);

        }
        [HttpPost]
        public async Task<ActionResult<Guid>>PostSpaces(CreateSpaceCommand command,CancellationToken cancellationToken)
        {
            var space = await _mediator.Send(command);
            return CreatedAtAction("createspace",new { },space);

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteSpaces(Guid Id,CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteSpaceCommand(Id));
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateSpacesBase(UpdateSpaceBaseCommand command,CancellationToken cancellationToken)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}

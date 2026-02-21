using CoWork.Application.Features.Members.Command.CreateMember;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MemberController(IMediator mediator)
        {
            _mediator = mediator;   
        }
        [HttpPost]
        public async Task<ActionResult<string>> Register([FromQuery]CreateMemberCommand command, CancellationToken cancellationToken)
        {
         var id = await _mediator.Send(command, cancellationToken);   
            return Ok(id);
         
        }
    }
}

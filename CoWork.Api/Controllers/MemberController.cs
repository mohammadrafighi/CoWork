using CoWork.Application.DTOs.Member;
using CoWork.Application.Features.Members.Command.ChangeMemberEmail;
using CoWork.Application.Features.Members.Command.ChangeMemberStatus;
using CoWork.Application.Features.Members.Command.CreateMember;
using CoWork.Application.Features.Members.Command.UpdateMemberProfile;
using CoWork.Application.Features.Members.Query.GetMembers;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAll(CancellationToken cancellationToken)
        {
            var Query = new GetAllMembersQuery();
            var members = await _mediator.Send(Query, cancellationToken);
              return Ok( members);  
        }  
        [HttpPut("UpdateProfile")]
        public async Task<ActionResult<Guid>> UpdateProfile([FromQuery]UpdateMemberProfileCommand request)
        {
            var memberId = _mediator.Send(request);
            return Ok(memberId);
        }
        [HttpPut("ChangeMemberStatus")]
        public async Task<ActionResult<bool>> ChangeMemberStatus(ChangeMemberStatusCommand request)
        {
            var memberStatus = _mediator.Send(request);
            return Ok(memberStatus);
        }
        [HttpPut("ChangeMemberEmail")]
        public async Task<ActionResult<bool>> ChangeMemberEmail(ChangeMemberEmailCommand request)
        {
            var ChangeStatus = _mediator.Send(request);
            return Ok(ChangeStatus);
        }

    }
}

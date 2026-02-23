using CoWork.Application.DTOs.Member;
using CoWork.Application.Features.Auth.Command.CahngePassword;
using CoWork.Application.Features.Auth.Query.GetAll;
using CoWork.Application.Features.Auth.Query.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;

namespace CoWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var query = new GetAllUserQuery();
            var users = await _mediator.Send(query);
            return Ok(users);   
        }
        [HttpGet("Login")]
        public async Task<ActionResult<string>> Login([FromQuery]LoginQuery command)
        {
            var jwt = await _mediator.Send(command);    
            return Ok(jwt);
        }
        [HttpPut]
        public async Task<ActionResult> ChangepassWord([FromQuery]ChangePasswordCommand command)
        {
           var userId = await _mediator.Send(command);   
            return Ok(userId);    

        }

    }
}

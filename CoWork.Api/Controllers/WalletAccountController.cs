using CoWork.Application.Features.Wallets.Command.ChargeWalletByAdminCommand;
using CoWork.Application.Features.Wallets.Command.ChargeWalletByManualCommand;
using CoWork.Application.Features.Wallets.Command.CreateWalletCommand;
using CoWork.Application.Features.Wallets.DTOs;
using CoWork.Application.Features.Wallets.Query.GetAllWalletQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletAccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WalletAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalletAccountDto>>> GetAll(CancellationToken cancellationToken)
        {
          var request = new GetAllWalletQuery();
          var wallets = await _mediator.Send(request,cancellationToken);
          return Ok(wallets); 
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWallet([FromQuery]CreateWalletAccountCommand request,CancellationToken cancellationToken)
        {
            var walletId = await _mediator.Send(request,cancellationToken);
            return Ok(walletId);
        }
        [HttpPut("ByAdmin")]
        public async Task<ActionResult<Guid>> ChargeWalletByAdmin([FromQuery] ChargeWalletByAdminCommand request, CancellationToken cancellationToken)
        {
            var TransactionId = await _mediator.Send(request, cancellationToken);
            return Ok(TransactionId);
        }
        [HttpPut("Manual")]
        public async Task<ActionResult<Guid>> ChargeWalletManual(Guid WalletId ,decimal Amount , IFormFile file , CancellationToken cancellationToken)
        {
            using var stream = file.OpenReadStream();

            var request = new ChargeWalletManualCommand(
                WalletId ,
                Amount ,
                stream,
                file.FileName,
                file.ContentType,
                file.Length
                );
            var transactionId = await _mediator.Send(request,cancellationToken) ;   
            return Ok(transactionId);   
        
        }
    }
}

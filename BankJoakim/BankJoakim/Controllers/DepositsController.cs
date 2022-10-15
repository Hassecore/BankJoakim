using BankJoakim.MediatR.Commands;
using BankJoakim.Resources.Deposits;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankJoakim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositsController : ControllerBase
    {
        readonly IMediator _mediator;
        public DepositsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeposit([FromBody] DepositCreateResource resource )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var commandResult = await _mediator.Send(new DepositCreateCommand(resource));

            if (!commandResult.HasSucceeded)
            {
                return BadRequest(commandResult.ErrorMessage);
            }

            return Ok(commandResult.Resource);
        }
    }
}

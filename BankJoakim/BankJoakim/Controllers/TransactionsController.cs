using BankJoakim.MediatR.Commands;
using BankJoakim.Resources.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankJoakim.Controllers
{
    public class TransactionsController : ControllerBase
    {
        readonly IMediator _mediator;
        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> CreateTransaction([FromBody] TransactionCreateResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var commandResult = await _mediator.Send(new TransactionCreateCommand(resource));

            if (!commandResult.HasSucceeded)
            {
                return BadRequest(commandResult.ErrorMessage);
            }

            return Ok(commandResult.Resource);
        }
    }
}

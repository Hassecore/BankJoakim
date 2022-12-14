using BankJoakim.MediatR.Commands;
using BankJoakim.MediatR.Queries;
using BankJoakim.Resources.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BankJoakim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        readonly IMediator _mediator;
        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAccount([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var account = await _mediator.Send(new AccountQuery(id));

            if (account.Id == Guid.Empty)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpGet]
        [Route("{id}/transactions")]
        public async Task<IActionResult> GetAccountTransactions([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var account = await _mediator.Send(new AccountTransactionsQuery(id));

            if (account.AccountId == Guid.Empty)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var commandResult = await _mediator.Send(new AccountCreateCommand(resource));

            if (!commandResult.HasSucceeded)
            {
                return BadRequest(commandResult.ErrorMessage);
            }

            return Ok(commandResult.Resource);
        }
    }
}

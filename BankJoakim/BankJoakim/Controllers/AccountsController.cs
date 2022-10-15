using BankJoakim.MediatR.Queries;
using BankJoakim.Models.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IEnumerable<Account> GetAccounts()
        {
            return new List<Account>
            {
                new Account
                {
                    Id = Guid.NewGuid(),
                    AccountName = "JoakimsHugeBankAccount",
                    Balance = 5000000000,
                    CreatedOn = DateTime.UtcNow
                }
            };

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
    }
}

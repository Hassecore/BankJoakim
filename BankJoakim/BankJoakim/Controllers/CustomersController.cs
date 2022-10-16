using BankJoakim.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BankJoakim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] int? skip, [FromQuery] int? take)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customers = await _mediator.Send(new CustomersQuery(skip ?? 0, take ?? 50));

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id, [FromQuery] bool includeAccounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = await _mediator.Send(new CustomerQuery(id, includeAccounts));

            if (customer.Id == Guid.Empty)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}

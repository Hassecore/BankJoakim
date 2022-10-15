using BankJoakim.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetCustomers([FromQuery] int skip, [FromQuery] int take)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customers = await _mediator.Send(new CustomersQuery(skip, take));

            return Ok(customers);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inflow.Modules.Customers.Core.Commands;
using Inflow.Modules.Customers.Core.Dto;
using Inflow.Modules.Customers.Core.Queries;
using Inflow.Shared.Abstractions.Commands;
using Inflow.Shared.Abstractions.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace Inflow.Modules.Customers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController: ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public CustomersController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCustomer command )
        {
            await _dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDetailsDto>> Get(Guid customerId)
        {
            var customer = await _dispatcher.QueryAsync(new GetCustomer {CustomerId = customerId});

            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}

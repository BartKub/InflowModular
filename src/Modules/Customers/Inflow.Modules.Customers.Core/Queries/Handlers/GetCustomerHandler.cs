using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Inflow.Modules.Customers.Core.Dal;
using Inflow.Modules.Customers.Core.Dto;
using Inflow.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Inflow.Modules.Customers.Core.Queries.Handlers
{
    internal class GetCustomerHandler: IQueryHandler<GetCustomer, CustomerDetailsDto>
    {
        private readonly CustomerDbContext _dbContext;

        public GetCustomerHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerDetailsDto> HandleAsync(GetCustomer query, CancellationToken cancellationToken = default)
        {
            var customer = await _dbContext.Customers.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == query.CustomerId, cancellationToken: cancellationToken);

            return customer?.AsDetailsDto();
        }
    }
}

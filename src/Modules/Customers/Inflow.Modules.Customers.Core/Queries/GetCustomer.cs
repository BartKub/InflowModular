using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inflow.Modules.Customers.Core.Dto;
using Inflow.Shared.Abstractions.Queries;

namespace Inflow.Modules.Customers.Core.Queries
{
    internal class GetCustomer: IQuery<CustomerDetailsDto>
    {
        public Guid CustomerId { get; set; }
    }
}

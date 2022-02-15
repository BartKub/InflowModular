using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inflow.Shared.Abstractions.Exception;

namespace Inflow.Modules.Customers.Core.Exceptions
{
    internal class CustomerNotActiveException: InflowException
    {
        public Guid CustomerId { get; } 
        public CustomerNotActiveException(Guid customerId) : base($"Customer with id {customerId} is inactive")
        {
            CustomerId = customerId;
        }
    }
}

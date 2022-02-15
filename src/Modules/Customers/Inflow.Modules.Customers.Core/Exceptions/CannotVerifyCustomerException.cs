using System;
using Inflow.Shared.Abstractions.Exception;

namespace Inflow.Modules.Customers.Core.Exceptions;

internal class CannotVerifyCustomerException : InflowException
{
    public Guid CustomerId { get; }
    public CannotVerifyCustomerException(Guid customerId) : base($"Customer with id {customerId} cannot be verified")
    {
        CustomerId = customerId;
    }
}
using System;
using Inflow.Shared.Abstractions.Exception;

namespace Inflow.Modules.Customers.Core.Exceptions;

internal class CannotCompleteCustomerException : InflowException
{
    public Guid CustomerId { get; }
    public CannotCompleteCustomerException(Guid customerId) : base($"Customer with id {customerId} cannot be completed")
    {
        CustomerId = customerId;
    }
}
using Inflow.Shared.Abstractions.Exception;

namespace Inflow.Modules.Customers.Core.Exceptions;

internal class InvalidIdentityException : InflowException
{
    public string Type { get; }

    public InvalidIdentityException(string type, string series)
        : base($"Identity type: '{type}', series: '{series}' is invalid.")
    {
        Type = type;
    }
}
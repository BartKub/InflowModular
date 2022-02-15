using Inflow.Shared.Abstractions.Exception;

namespace Inflow.Shared.Abstractions.Kernel.Exceptions;

public class InvalidNationalityException : InflowException
{
    public string Nationality { get; }

    public InvalidNationalityException(string nationality) : base($"Nationality: '{nationality}' is invalid.")
    {
        Nationality = nationality;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inflow.Shared.Abstractions.Exception;

namespace Inflow.Shared.Abstractions.Kernel.Exceptions
{
    public class InvalidEmailException: InflowException
    {
        public string Email { get; }

        public InvalidEmailException(string email) : base($"Email: {email} is invalid ")
        {
            Email = email;
        }
    }
}

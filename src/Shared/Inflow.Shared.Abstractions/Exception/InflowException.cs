using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inflow.Shared.Abstractions.Exception
{
    public abstract class InflowException: System.Exception
    {
        protected InflowException(string message) : base(message)
        {

        }
    }
}

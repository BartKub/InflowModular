using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inflow.Shared.Abstractions.Commands;

namespace Inflow.Modules.Customers.Core.Commands
{
    public record CreateCustomer(string Email): ICommand;
}


using System.Runtime.CompilerServices;
using Inflow.Modules.Customers.Core.Dal;
using Inflow.Modules.Customers.Core.Dal.Repositories;
using Inflow.Modules.Customers.Core.Repositories;
using Inflow.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("Inflow.Modules.Customers.Api")]
namespace Inflow.Modules.Customers.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddPostgres<CustomerDbContext>();
            return services;
        }
    }
}

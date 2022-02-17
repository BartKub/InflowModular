using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inflow.Shared.Infrastructure.Postgres
{
    public static class Extensions
    {
        internal static IServiceCollection AddPostgres(this IServiceCollection service)
        {
            var options = service.GetOptions<PostgresOptions>("postgres");
            service.AddSingleton(options);
            service.AddHostedService<DbContextAppInitializer>();

            return service;
        }

        public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T: DbContext
        {
            var options = services.GetOptions<PostgresOptions>("postgres");

            services.AddDbContext<T>(x=>x.UseNpgsql(options.ConnectionString));

            return services;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inflow.Modules.Customers.Core.Domain.Entities;
using Inflow.Modules.Customers.Core.Dto;

namespace Inflow.Modules.Customers.Core.Queries.Handlers
{
    internal static class Extensions
    {
        public static CustomerDto AsDto(this Customer customer) => customer.Map<CustomerDto>();
        public static CustomerDetailsDto AsDetailsDto(this Customer customer)
        {
            var dto = customer.Map<CustomerDetailsDto>();
            dto.Address = customer.Address;
            dto.Notes = customer.Notes;
            dto.Identity = customer.Identity is null
                ? null
                : new IdentityDto
                {
                    Type = customer.Identity.Type,
                    Series = customer.Identity.Series
                };
            return dto;
        }


        private static T Map<T>(this Customer customer) where T : CustomerDto, new() => new()
        {
            Id = customer.Id,
            Email = customer.Email,
            Nationality = customer.Nationality,
            Name = customer.Name,
            FullName = customer.FullName,
            CreatedAt = customer.CreatedAt,
            IsActive = customer.IsActive
        };
    }
}

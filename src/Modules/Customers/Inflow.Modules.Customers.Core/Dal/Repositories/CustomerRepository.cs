using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inflow.Modules.Customers.Core.Domain.Entities;
using Inflow.Modules.Customers.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inflow.Modules.Customers.Core.Dal.Repositories
{

    internal class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerDbContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
            _customers = context.Customers;
        }

        public Task<bool> ExistsAsync(string name)
            => _customers.AnyAsync(x => x.Name == name);

        public Task<Customer> GetAsync(Guid id)
            => _customers.SingleOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Customer customer)
        {
            await _customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}

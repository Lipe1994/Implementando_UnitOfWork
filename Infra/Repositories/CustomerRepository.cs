using Core.Contracts.Repositories;
using Core.Models;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<Customer> Get(Guid id)
        {
            return await _dataContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> List()
        {
            return await _dataContext.Customers.ToListAsync();
        }

        public Task Save(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            return Task.CompletedTask;
        }

        public Task Update(Customer customer)
        {
            _dataContext.Customers.Update(customer);
            return Task.CompletedTask;
        }
    }
}

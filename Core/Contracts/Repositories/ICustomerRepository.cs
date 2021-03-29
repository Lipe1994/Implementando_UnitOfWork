using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        Task Save(Customer customer);
        Task Update( Customer customer);
        Task<Customer> Get(Guid id);
        Task<IEnumerable<Customer>> List();
    }
}

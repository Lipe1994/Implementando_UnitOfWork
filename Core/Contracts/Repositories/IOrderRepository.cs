using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task Save(Order order);
        Task Update(Order order);
        Task<Order> Get(Guid id);
        Task<IEnumerable<Order>> List();
    }
}

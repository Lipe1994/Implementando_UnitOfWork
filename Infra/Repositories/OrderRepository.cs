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
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<Order> Get(Guid id)
        {
            return await _dataContext.Orders.Include(x => x.Customer).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> List()
        {
            return await _dataContext.Orders.Include(x => x.Customer).ToListAsync();
        }

        public Task Update(Order order)
        {
            _dataContext.Orders.Update(order);
            return Task.CompletedTask;
        }

        Task IOrderRepository.Save(Order order)
        {
            _dataContext.Orders.Update(order);
            return Task.CompletedTask;
        }
    }
}

using Core.Contracts.Repositories;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkAPI.Requests;

namespace UnitOfWorkAPI.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IOrderRepository orderRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost()]
        public async Task<ActionResult> New(OrderRequest orderRequest) 
        {
            if (orderRequest.Customer == null || orderRequest.Customer.Name.Equals(""))
            {
                throw new Exception("Customer not found");
            }

            var customer = new Customer() 
            {
                Name = orderRequest?.Customer.Name
            };
            await customerRepository.Save(customer);

            var order = new Order()
            {
                Customer = customer,
                Number = orderRequest.Number,
            };
            await orderRepository.Save(order);

            unitOfWork.Commit();

            return Ok();
        }

        [HttpPut("{id}/Update")]
        public async Task<ActionResult> Update(Guid id, OrderRequest orderRequest)
        {
            if (orderRequest.Customer == null || orderRequest.Customer.Name.Equals(""))
            {
                throw new Exception("Customer not found");
            }

            var order = await orderRepository.Get(id);

            if (order == null) 
            {
                throw new Exception("Order not found");
            }

            order.Number = orderRequest.Number;
            order.Customer.Name = orderRequest.Customer.Name;

            await orderRepository.Update(order);

            unitOfWork.Commit();

            return Ok();
        }

        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> List()
        {
            var orders = await orderRepository.List();
            return Ok(orders.Select(x => new OrderDTO {
                    Id = x.Id,
                    Number = x.Number,
                    Customer = new CustomerDTO() {
                        Id = x.Customer.Id,
                        Name = x.Customer.Name
                    }
                })
            );
        }
        
        [HttpGet("{id}/Get")]
        public async Task<ActionResult<OrderDTO>> Get(Guid id)
        {
            var order = await orderRepository.Get(id);

            return Ok(new OrderDTO
            {
                Id = order.Id,
                Number = order.Number,
                Customer = new CustomerDTO()
                {
                    Id = order.Customer.Id,
                    Name = order.Customer.Name
                }
            });
        }


    }
}

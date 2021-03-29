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
    public class CustomerController : BaseController
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerController(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost()]
        public async Task<ActionResult> New(CustomerRequest customerRequest) 
        {
            await customerRepository.Save(new Customer() {
                Name = customerRequest.Name
            });

            unitOfWork.Commit();

            return Ok();
        }

        [HttpPut("{id}/Update")]
        public async Task<ActionResult> Update(Guid id, CustomerRequest customerRequest)
        {

            await customerRepository.Update(
                new Customer()
                {
                    Id = id,
                    Name = customerRequest.Name
                }    
            );

            unitOfWork.Commit();

            return Ok();
        }

        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> List()
        {
            var customers = await customerRepository.List();
            return Ok(customers.Select(x => new CustomerDTO() {
                Id = x.Id,
                Name = x.Name
            }));
        }
        
        [HttpGet("{id}/Get")]
        public async Task<ActionResult<OrderDTO>> Get(Guid id)
        {
            var customer = await customerRepository.Get(id);

            return Ok(new CustomerDTO()
            {
                Id = customer.Id,
                Name = customer.Name
            });
        }


    }
}

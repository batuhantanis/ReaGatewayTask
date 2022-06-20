using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Domain.Services.Abstract;
using Data.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet("getcustomerlist")]
        public async Task<List<CustomerEntity>> GetCustomerList()
        {
            var customers = await _customerService.GetCustomersList();
            return customers;
        }
        
        
        [HttpGet("getcustomer/{id}")]
        public async Task<CustomerEntity> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomer(id);
            return customer;
        }
        
        [HttpPost("createcustomer")]
        public async Task<bool> CreateCustomer([FromBody] CustomerEntity entity)
        {
            var res = await _customerService.CreateCustomer(entity);
            return res;
        }
        
        [HttpPost("createcustomerlist")]
        public async Task<bool> CreateCustomerList([FromBody] List<CustomerEntity> entities)
        {
            var res = await _customerService.CreateCustomerList(entities);
            return res;
        }
        
        [HttpPost("updatecustomer")]
        public async Task<bool> UpdateCustomer([FromBody] CustomerEntity entity)
        {
            var res = await _customerService.UpdateCustomer(entity);
            return res;
        }
        
        [HttpPost("updatecustomerlist")]
        public async Task<bool> UpdateCustomerList([FromBody] List<CustomerEntity> entities)
        {
            var res = await _customerService.UpdateCustomerList(entities);
            return res;
        }
        
        [HttpDelete("deletecustomer/{id}")]
        public async Task<bool> DeleteCustomer(int id)
        {
            var res = await _customerService.DeleteCustomer(id);
            return res;
        }
        
        [HttpDelete("deletecustomerlist")]
        public async Task<bool> DeleteCustomerList([FromBody] List<CustomerEntity> entities)
        {
            var res = await _customerService.DeleteCustomerList(entities);
            return res;
        }
    }
}
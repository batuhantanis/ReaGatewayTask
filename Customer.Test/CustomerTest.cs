using System;
using Data.Entities.Concrete;
using MockCustomerService.Concrete;
using Xunit;

namespace Customer.Test
{
    public class CustomerTest : IClassFixture<CustomerTestService>
    {
        private readonly CustomerTestService _customerTestService;

        public CustomerTest(CustomerTestService customerTestService)
        {
            _customerTestService = customerTestService;
        }
        
        
        [Fact]
        public void GetCustomerList()
        {
            var result =  _customerTestService.GetCustomersList();
          
            Assert.NotEmpty(result);
        }
        
        [Fact]
        public void GetCustomer()
        {
            var result =  _customerTestService.GetCustomer(3);
          
            Assert.NotNull(result);
        }
        
        [Fact]
        public void CreateCustomer()
        {
            var result =  _customerTestService.CreateCustomer();
          
            Assert.True(result);
        }
        
        [Fact]
        public void UpdateCustomer()
        {
          var customer =  new CustomerEntity()
            {
                Id = 1,
                Name = "Batuhan",
                Email = "batuhan@hotmail.com",
                AddressId = 2,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var result =  _customerTestService.UpdateCustomer(customer);
          
            Assert.True(result);
        }
        
        [Fact]
        public void DeleteCustomer()
        {
            var result = _customerTestService.DeleteCustomer(2);
            
            Assert.True(result);
        }
    }
}
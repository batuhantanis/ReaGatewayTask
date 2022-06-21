using System;
using System.Collections.Generic;
using Customer.API.Controllers;
using Customer.Domain.Services.Abstract;
using Data.Entities.Concrete;
using MockCustomerService.Concrete;
using Xunit;

namespace Customer.Test
{
    public class CustomerTest
    {
        private readonly CustomerController _controller;
        private readonly ICustomerService _customerService;

        public CustomerTest()
        {
            _customerService = new CustomerTestService();
            _controller = new CustomerController(_customerService);
        }

        [Fact]
        public async void GetCustomerList()
        {
            var okResult = await _controller.GetCustomerList();
            Assert.NotEmpty(okResult);
        }
        
        [Fact]
        public async void GetCustomer()
        {
            var okResult = await _controller.GetCustomer(3);
            Assert.NotNull(okResult);
        }
        
        [Fact]
        public async void CreateCustomer()
        {
            var customer = new CustomerEntity()
            {
                Id = 1,
                Name = "Batuhan",
                Email = "test@hotmail.com",
                AddressId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var okResult = await _controller.CreateCustomer(customer);
            Assert.True(okResult);
        }
        
        [Fact]
        public async void CreateCustomerList()
        {
            List<CustomerEntity> entities = new List<CustomerEntity>()
            {
                new CustomerEntity()
                {
                    Id = 1,
                    Name = "Batuhan",
                    Email = "test@hotmail.com",
                    AddressId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CustomerEntity()
                {
                    Id = 2,
                    Name = "Nikki",
                    Email = "nikki@hotmail.com",
                    AddressId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
            var okResult = await _controller.CreateCustomerList(entities);
            Assert.True(okResult);
        }

        [Fact]
        public async void UpdateCustomer()
        {
            var customer = new CustomerEntity()
            {
                Id = 1,
                Name = "Test",
                Email = "test@hotmail.com",
                AddressId = 3,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var okResult = await _controller.UpdateCustomer(customer);
            Assert.True(okResult);
        }
        
        [Fact]
        public async void UpdateCustomerList()
        {
            List<CustomerEntity> entities = new List<CustomerEntity>()
            {
                new CustomerEntity()
                {
                    Id = 1,
                    Name = "Test",
                    Email = "test@hotmail.com",
                    AddressId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CustomerEntity()
                {
                    Id = 2,
                    Name = "Jashua",
                    Email = "jashua@hotmail.com",
                    AddressId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };

            var okResult = await _controller.UpdateCustomerList(entities);
            Assert.True(okResult);
        }

        [Fact]
        public async void DeleteCustomer()
        {
            var okResult = await _controller.DeleteCustomer(2);
            Assert.True(okResult);
        }
        
        [Fact]
        public async void DeleteCustomerList()
        {
            
            List<CustomerEntity> entities = new List<CustomerEntity>()
            {
                new CustomerEntity()
                {
                    Id = 1,
                    Name = "Test",
                    Email = "test@hotmail.com",
                    AddressId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CustomerEntity()
                {
                    Id = 2,
                    Name = "Jashua",
                    Email = "jashua@hotmail.com",
                    AddressId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
            var okResult = await _controller.DeleteCustomerList(entities);
            Assert.True(okResult);
        }
    }
}
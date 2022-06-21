using System;
using System.Collections.Generic;
using Data.Entities.Concrete;
using MockOrderService.Concrete;
using Order.API.Controllers;
using Order.Domain.Services.Abstract;
using Xunit;

namespace Order.Test
{
    public class OrderTest
    {
        private readonly OrderController _controller;
        private readonly IOrderService _orderService;

        public OrderTest()
        {
            _orderService = new OrderTestService();
            _controller = new OrderController(_orderService);
        }
        
        [Fact]
        public async void GetOrderList()
        {
            var okResult = await _controller.GetOrderList();
            Assert.NotEmpty(okResult);
        }
        
        [Fact]
        public async void GetOrder()
        {
            var okResult = await _controller.GetOrder(3);
            Assert.NotNull(okResult);
        }
        
        [Fact]
        public async void CreateOrder()
        {
            var order = new OrderEntity()
            {
                Id = 5,
                Quantity = 20,
                Price = 550,
                Status = "Success",
                CustomerId = 2,
                AddressId = 3,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var okResult = await _controller.CreateOrder(order);
            Assert.True(okResult);
        }
        
        [Fact]
        public async void CreateOrderList()
        {
            List<OrderEntity> entities = new List<OrderEntity>()
            {
                new OrderEntity()
                {
                    Id = 5,
                    Quantity = 20,
                    Price = 550,
                    Status = "Success",
                    CustomerId = 2,
                    AddressId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new OrderEntity()
                {
                    Id = 6,
                    Quantity = 15,
                    Price = 320,
                    Status = "Success",
                    CustomerId = 1,
                    AddressId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
            var okResult = await _controller.CreateOrderList(entities);
            Assert.True(okResult);
        }

        [Fact]
        public async void UpdateOrder()
        {
            var Order = new OrderEntity()
            {
                Id = 1,
                Quantity = 1,
                Price = 300,
                Status = "ChangedStatus",
                CustomerId = 1,
                AddressId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var okResult = await _controller.UpdateOrder(Order);
            Assert.True(okResult);
        }
        
        [Fact]
        public async void UpdateOrderList()
        {
            List<OrderEntity> entities = new List<OrderEntity>()
            {
                new OrderEntity()
                {
                    Id = 1,
                    Quantity = 1,
                    Price = 300,
                    Status = "ChangedStatus",
                    CustomerId = 1,
                    AddressId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new OrderEntity()
                {
                    Id = 2,
                    Quantity = 4,
                    Price = 800,
                    Status = "ChangedStatus",
                    CustomerId = 3,
                    AddressId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };

            var okResult = await _controller.UpdateOrderList(entities);
            Assert.True(okResult);
        }

        [Fact]
        public async void DeleteOrder()
        {
            var okResult = await _controller.DeleteOrder(1);
            Assert.True(okResult);
        }
        
        [Fact]
        public async void DeleteOrderList()
        {
            
            List<OrderEntity> entities = new List<OrderEntity>()
            {
                new OrderEntity()
                {
                    Id = 1,
                    Quantity = 1,
                    Price = 300,
                    Status = "ChangedStatus",
                    CustomerId = 1,
                    AddressId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new OrderEntity()
                {
                    Id = 2,
                    Quantity = 4,
                    Price = 800,
                    Status = "ChangedStatus",
                    CustomerId = 3,
                    AddressId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
            var okResult = await _controller.DeleteOrderList(entities);
            Assert.True(okResult);
        }

        [Fact]
        public async void ChangeStatus()
        {
            var okResult = await _controller.ChangeStatus(2, "ChangedStatus");
            Assert.True(okResult);
        }
    }
}
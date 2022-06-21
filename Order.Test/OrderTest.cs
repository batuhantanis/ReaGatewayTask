using System;
using Data.Entities.Concrete;
using MockOrderService.Concrete;
using Xunit;

namespace Order.Test
{
    public class OrderTest : IClassFixture<OrderTestService>
    {
        private readonly OrderTestService _orderTestService;

        public OrderTest(OrderTestService orderTestService)
        {
            _orderTestService = orderTestService;
        }

        [Fact]
        public void GetOrderList()
        {
          var result =  _orderTestService.GetOrdersList();
          
          Assert.NotEmpty(result);
        }
        
        [Fact]
        public void GetOrder()
        {
            var result =  _orderTestService.GetOrder(3);
          
            Assert.NotNull(result);
        }
        
        [Fact]
        public void CreateOrder()
        {
            var result =  _orderTestService.CreateOrder();
          
            Assert.True(result);
        }
        
        [Fact]
        public void UpdateOrder()
        {
            var order = new OrderEntity()
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
            var result =  _orderTestService.UpdateOrder(order);
          
            Assert.True(result);
        }
        
        [Fact]
        public void DeleteOrder()
        {
            var result = _orderTestService.DeleteOrder(2);
            
            Assert.True(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entities.Concrete;
using MockOrderService.Abstract;

namespace MockOrderService.Concrete
{
    public class OrderTestService : IOrderTestService
    {
        private List<OrderEntity> _entities;
        public OrderTestService()
        {
            _entities = new List<OrderEntity>()
            {
                new OrderEntity()
                {
                    Id = 1,
                    Quantity = 1,
                    Price = 180,
                    Status = "Transferred",
                    CustomerId = 1,
                    AddressId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new OrderEntity()
                {
                    Id = 2,
                    Quantity = 1,
                    Price = 300,
                    Status = "Transferred",
                    CustomerId = 1,
                    AddressId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new OrderEntity()
                {
                    Id = 3,
                    Quantity = 1,
                    Price = 550,
                    Status = "Transferred",
                    CustomerId = 1,
                    AddressId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new OrderEntity()
                {
                    Id = 4,
                    Quantity = 1,
                    Price = 880,
                    Status = "Transferred",
                    CustomerId = 1,
                    AddressId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
        }
        
        public List<OrderEntity> GetOrdersList()
        {
            return _entities;
        }

        public OrderEntity GetOrder(int id)
        {
            return _entities.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateOrder()
        {
            try
            {
                var order = new OrderEntity()
                {
                    Id = 1,
                    Quantity = 1,
                    Price = 180,
                    Status = "Transferred",
                    CustomerId = 1,
                    AddressId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _entities.Add(order);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
               
        }

        public bool UpdateOrder(OrderEntity entity)
        {
            if (entity != null)
            {
                var _entity = _entities.Find(x => x.Id == entity.Id);
                _entities.Remove(_entity);
                _entities.Add(entity);
                return true;
            }

            return false;
        }
        public bool DeleteOrder(int id)
        {
            try
            {
                var entity = _entities.FirstOrDefault(x => x.Id == id);
                _entities.Remove(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
                
            

        }
      
    }
}
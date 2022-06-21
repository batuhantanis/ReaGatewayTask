using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities.Concrete;
using Order.Domain.Services.Abstract;

namespace MockOrderService.Concrete
{
    public class OrderTestService : IOrderService
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
        public async Task<List<OrderEntity>> GetOrdersList()
        {
            return _entities;
        }

        public async Task<OrderEntity> GetOrder(int id)
        {
            var order = _entities.FirstOrDefault(x => x.Id == id);
            return order;
        }

        public async Task<bool> CreateOrder(OrderEntity entity)
        {
            try
            {
                _entities.Add(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> CreateOrderList(List<OrderEntity> entities)
        {
            try
            {
                _entities.AddRange(entities);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrder(OrderEntity entity)
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

        public async Task<bool> UpdateOrderList(List<OrderEntity> entities)
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    var _entity = _entities.Find(x => x.Id == entity.Id);
                    _entities.Remove(_entity);
                    _entities.Add(entity);
                    
                }
                return true;
            }
            
            return false;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            try
            {
                var order = _entities.FirstOrDefault(x => x.Id == id);
                _entities.Remove(order);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderList(List<OrderEntity> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    var order = _entities.FirstOrDefault(x => x.Id == entity.Id);
                    _entities.Remove(order);
                }
               
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> ChangeStatus(int id, string status)
        {
            try
            {
                var order = _entities.FirstOrDefault(x => x.Id == id);
                order.Status = status;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }
    }
}
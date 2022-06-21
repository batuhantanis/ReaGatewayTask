using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Services.Abstract;
using Data.Entities.Concrete;

namespace MockCustomerService.Concrete
{
    public class CustomerTestService : ICustomerService
    {
        private List<CustomerEntity> _entities;
        public CustomerTestService()
        {
            _entities = new List<CustomerEntity>()
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
                    Name = "Mehmet",
                    Email = "mehmet@hotmail.com",
                    AddressId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CustomerEntity()
                {
                    Id = 3,
                    Name = "Jason",
                    Email = "jason@hotmail.com",
                    AddressId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CustomerEntity()
                {
                    Id = 4,
                    Name = "Haluk",
                    Email = "haluk@hotmail.com",
                    AddressId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
        }
        public async Task<List<CustomerEntity>> GetCustomersList()
        {
            return  _entities;
        }

        public async Task<CustomerEntity> GetCustomer(int id)
        {
            var customer = _entities.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public async Task<bool> CreateCustomer(CustomerEntity entity)
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

        public async Task<bool> CreateCustomerList(List<CustomerEntity> entities)
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

        public async Task<bool> UpdateCustomer(CustomerEntity entity)
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

        public async Task<bool> UpdateCustomerList(List<CustomerEntity> entities)
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

        public async Task<bool> DeleteCustomer(int id)
        {
            try
            {
                var customer = _entities.FirstOrDefault(x => x.Id == id);
                _entities.Remove(customer);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCustomerList(List<CustomerEntity> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    var customer = _entities.FirstOrDefault(x => x.Id == entity.Id);
                    _entities.Remove(customer);
                }
               
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Services.Abstract;
using Data.Entities.Concrete;
using Data.Repository.Abstract;

namespace Customer.Domain.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<CustomerEntity>> GetCustomersList()
        {
            var customers = await _unitOfWork.Customer.GetAll();
            return customers.ToList();
        }

        public async Task<CustomerEntity> GetCustomer(int id)
        {
           
            var customer = await _unitOfWork.Customer.Get(x => x.Id == id);
            return customer;
        }

        public async Task<bool> CreateCustomer(CustomerEntity entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Customer.Insert(entity);
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> CreateCustomerList(List<CustomerEntity> entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Customer.InsertRange(entity);
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateCustomer(CustomerEntity entity)
        {
            if (entity != null)
            {
                _unitOfWork.Customer.Update(entity);
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateCustomerList(List<CustomerEntity> entities)
        {
            if (entities.Count != 0)
            {
                foreach (CustomerEntity entity in entities)
                {
                    _unitOfWork.Customer.Update(entity);
                }
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            if (id != 0)
            {
                await _unitOfWork.Customer.Delete(id);
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCustomerList(List<CustomerEntity> entities)
        {
            if (entities != null)
            {
                _unitOfWork.Customer.DeleteRange(entities);
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }
    }
}
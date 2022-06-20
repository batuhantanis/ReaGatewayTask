using System;
using System.Collections;
using System.Collections.Generic;
using Data.Entities.Abstract;
using Data.Entities.Concrete;

namespace Data.Entities.Concrete
{
    public class CustomerEntity : BaseEntity,IEntity
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }

        public ICollection<OrderEntity> OrderEntities  { get; set; }
        
    }
}
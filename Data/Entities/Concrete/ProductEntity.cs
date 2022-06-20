using System.Collections;
using System.Collections.Generic;
using Data.Entities.Abstract;

namespace Data.Entities.Concrete
{
    public class ProductEntity : BaseEntity,IEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<OrderEntity> OrderEntities { get; set; }
    }
}
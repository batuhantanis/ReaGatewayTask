using Data.Entities.Abstract;

namespace Data.Entities.Concrete
{
    public class OrderEntityProductEntity : IEntity
    {
        
        public int OrderEntitiesId { get; set; }
        public int ProductsId { get; set; }
    }
}
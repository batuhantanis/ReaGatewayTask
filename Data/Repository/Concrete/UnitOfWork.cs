using System.Threading.Tasks;
using Data.Entities.Concrete;
using Data.Repository.Abstract;

namespace Data.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReaDbContext _context;
        private IGenericRepository<OrderEntity> _order;
        private IGenericRepository<CustomerEntity> _customer { get; }
        private IGenericRepository<ProductEntity> _product { get; }
        private IGenericRepository<AddressEntity> _address { get; }

        public UnitOfWork(ReaDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<OrderEntity> Order => _order ?? new GenericRepository<OrderEntity>(_context);

        public IGenericRepository<CustomerEntity> Customer =>
            _customer ?? new GenericRepository<CustomerEntity>(_context);

        public IGenericRepository<ProductEntity> Product => _product ?? new GenericRepository<ProductEntity>(_context);
        public IGenericRepository<AddressEntity> Address => _address ?? new GenericRepository<AddressEntity>(_context);
        
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            
        }
    }
}
using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Concrete
{
    public class CustomerMapping : BaseEntityMapping<CustomerEntity>
    {
        public override void upConfigure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasOne(x => x.Address).WithMany(x => x.Customer).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.OrderEntities).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
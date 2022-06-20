using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Concrete
{
    public class OrderMapping : BaseEntityMapping<OrderEntity>
    {
        public override void upConfigure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.HasOne(x => x.Customer).WithMany(x => x.OrderEntities).HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Products).WithMany(x => x.OrderEntities);

            builder.HasOne(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
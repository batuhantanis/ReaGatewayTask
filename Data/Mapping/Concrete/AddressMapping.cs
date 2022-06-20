using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Concrete
{
    public class AddressMapping : BaseEntityMapping<AddressEntity>
    {
        public override void upConfigure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.CityCode).IsRequired();
            builder.HasMany(x => x.Customer).WithOne(x => x.Address).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Orders).WithOne(x => x.Address).HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
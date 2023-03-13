using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APP.Domain.Mapping;

public class BasketMapping : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.Items)
            .WithOne(bi => bi.Basket)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
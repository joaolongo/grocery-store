using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APP.Domain.Mapping;

public class BasketItemMapping : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Quantity).IsRequired();

        builder.HasOne(e => e.Item)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(e => e.Basket)
            .WithMany(b => b.Items)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
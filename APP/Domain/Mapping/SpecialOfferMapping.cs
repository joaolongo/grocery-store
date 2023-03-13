using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APP.Domain.Mapping;

public class SpecialOfferMapping : IEntityTypeConfiguration<SpecialOffer>
{
    public void Configure(EntityTypeBuilder<SpecialOffer> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(e => e.Percentage)
            .HasColumnType("decimal(3, 2)")
            .IsRequired();

        builder.Property(p => p.RequiredAmount);

        builder.HasOne(p => p.Item)
            .WithOne(p => p.SpecialOffer)
            .HasForeignKey<SpecialOffer>(p => p.ItemId)
            .IsRequired(false);
        
        builder.HasOne(p => p.DiscountItem)
            .WithMany()
            .HasForeignKey(p => p.DiscountItemId)
            .IsRequired(false);

        builder.Property(p => p.DiscountItemId)
            .IsRequired(false);

        builder.Property(p => p.Description);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APP.Domain.Mapping;

public class ItemMapping : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Price)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder.HasOne(x => x.SpecialOffer)
            .WithOne(p => p.Item)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
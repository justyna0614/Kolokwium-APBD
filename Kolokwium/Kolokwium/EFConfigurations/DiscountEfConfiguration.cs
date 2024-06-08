using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.EFConfigurations;

public class DiscountEfConfiguration :IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder) //Dopuszcza implementację tylko jednej metody Configure!!!

    {
        builder.HasKey(s => s.IdDiscount);
        builder.Property(s => s.IdDiscount).ValueGeneratedOnAdd();
        
        builder.Property(s => s.Value).IsRequired();
        builder.Property(s => s.DateFrom).IsRequired();
        builder.Property(s => s.DateTo).IsRequired();
    }
}
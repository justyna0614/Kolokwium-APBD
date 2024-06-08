using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.EFConfigurations;

public class SaleEfConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder) //Dopuszcza implementację tylko jednej metody Configure!!!
    
    {
        builder.HasKey(s => s.IdSale);
        builder.Property(s => s.IdSale).ValueGeneratedOnAdd();
        builder.Property(s => s.CreatedAt).IsRequired();
        
        builder.HasOne(p => p.IdClientNavigation)
            .WithMany(p => p.Sales)
            .HasForeignKey(p => p.IdClinet)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.IdSubscriptionNavigation)
            .WithMany(p => p.Sales)
            .HasForeignKey(p => p.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
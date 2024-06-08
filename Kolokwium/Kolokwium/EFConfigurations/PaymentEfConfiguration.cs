using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.EFConfigurations;

public class PaymentEfConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder) //Dopuszcza implementację tylko jednej metody Configure!!!
    
    {
        builder.HasKey(s => s.IdPayment);
        builder.Property(s => s.IdPayment).ValueGeneratedOnAdd();
        builder.Property(s => s.Date).IsRequired();
        
        builder.HasOne(p => p.IdClientNavigation)
            .WithMany(p => p.Payments)
            .HasForeignKey(p => p.IdClinet)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.IdSubscriptionNavigation)
            .WithMany(p => p.Payments)
            .HasForeignKey(p => p.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
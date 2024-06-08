using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.EFConfigurations;

public class ClientEfConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder) //Dopuszcza implementację tylko jednej metody Configure!!!

    {
        builder.HasKey(s => s.IdClient);
        builder.Property(s => s.IdClient).ValueGeneratedOnAdd();
        
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Email).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Phone).IsRequired(false).HasMaxLength(100);
    }
}
using Kolokwium.EFConfigurations;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Context;

public class AppDbContext : DbContext //Tworzymy dwa konstruktowy dla DbContext
{
    public DbSet<Client> Client { get; set; } //Dodajemy DbSety dla naszych modeli
    public DbSet<Discount> Discount { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Sale> Sale { get; set; }
    public DbSet<Subscription> Subscription { get; set; }

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) :
        base(options) //Tworzymy konstruktor z parametrem options -> bo będziemy przekazywać opcje konfiguracji bazy danych
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientEfConfiguration());
        modelBuilder.ApplyConfiguration(new DiscountEfConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentEfConfiguration());
        modelBuilder.ApplyConfiguration(new SaleEfConfiguration());
        modelBuilder.ApplyConfiguration(new SubscriptionEfConfiguration());
    }
}
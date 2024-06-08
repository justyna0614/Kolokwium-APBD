namespace Kolokwium.Models;

public class Subscription
{
    public int IdSubscription { get; set; }
    public String Name { get; set; }
    public String RenewalPeriod { get; set; }
    public DateTime EndTime { get; set; }
    public int Price { get; set; }
    
    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
    public virtual ICollection<Discount> Discounts { get; set; }
}
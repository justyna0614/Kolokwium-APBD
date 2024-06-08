namespace Kolokwium.Models;

public class Discount
{
    public int IdDiscount { get; set; }
    public String Value { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdSubscription { get; set; }
    
    public virtual  Subscription IdSubscriptionNavigation { get; set; }
}
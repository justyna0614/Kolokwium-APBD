namespace Kolokwium.Controllers.DTO;

public class SubscriptionDTO
{
    public int IdSubscription { get; set; }
    public String Name { get; set; }
    public String RenewalPeriod { get; set; }
    public DateTime EndTime { get; set; }
    public int Price { get; set; }
}
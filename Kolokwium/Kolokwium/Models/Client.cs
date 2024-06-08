namespace Kolokwium.Models;

public class Client
{
    public int IdClient { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
    public String? Phone { get; set; }
    
    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
}
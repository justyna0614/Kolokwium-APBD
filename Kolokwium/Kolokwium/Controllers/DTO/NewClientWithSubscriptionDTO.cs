namespace Kolokwium.Controllers.DTO;

public class NewClientWithSubscriptionDTO
{
    public ClientDTO ClientDto { get; set; }
    public List<SubscriptionDTO> subscriptions { get; set; }
}
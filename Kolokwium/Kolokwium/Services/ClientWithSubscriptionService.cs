using Kolokwium.Context;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Services;

public class ClientWithSubscriptionService
{
    private readonly AppDbContext _context;

    public ClientWithSubscriptionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Client> getClientSubscription()
    {
        return await _context.Client
            .Include(c => c.Sales).ThenInclude(s => s.IdSubscription)
            .FirstAsync(); 
    } 
}
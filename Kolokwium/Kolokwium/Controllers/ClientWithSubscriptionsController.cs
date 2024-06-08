using System.Diagnostics;
using Kolokwium.Context;
using Kolokwium.Controllers.DTO;
using Kolokwium.Exceptions;
using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

[Route("/api/client")]
[ApiController]
public class ClientWithSubscriptionsController : ControllerBase
{
    private readonly ClientWithSubscriptionService _service;


    public ClientWithSubscriptionsController(ClientWithSubscriptionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<Client> GetClientSub([FromBody] ClientDTO client)
    {
        if (client == null)
        {
            throw new ClientNotFoundException();
        }
        var result = await _service.getClientSubscription();
        return result;
    }
}
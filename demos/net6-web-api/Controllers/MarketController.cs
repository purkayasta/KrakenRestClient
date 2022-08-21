using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KrakenClient.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace net6_web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarketController : ControllerBase
{
    private readonly IKrakenClient krakenClient;

    public MarketController(IKrakenClient krakenClient)
    {
        this.krakenClient = krakenClient;
    }

    [HttpGet("ServerTime")]
    public async Task<IActionResult> Get()
    {
        var serverTime = await this.krakenClient.MarketData().GetServerTime();
        return Ok(serverTime);
    }
}
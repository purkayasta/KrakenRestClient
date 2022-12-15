using KrakenRestClient.Contracts;
using KrakenRestClient.Models.UserTrading;
using Microsoft.AspNetCore.Mvc;

namespace net6_web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserDataController : ControllerBase
{
    private readonly IKrakenClient _krakenClient;

    public UserDataController(IKrakenClient krakenClient)
    {
        _krakenClient = krakenClient;
    }

    [HttpPost("GetAccountBalance")]
    public async Task<IActionResult> GetAccountBalance()
    {
        var result = await _krakenClient.UserData().GetAccountBalance();
        return Ok(result);
    }

    [HttpPost("GetTradeBalance")]
    public async Task<IActionResult> GetTradeBalance(string asset)
    {
        return Ok(await _krakenClient.UserData().GetTradeBalance(asset));
    }

    [HttpPost("AddOrder")]
    public async Task<IActionResult> AddOrder()
    {
        var buyOrder = new AddOrderRequest
        {
            Pair = "",
            OrderType = null,
            Type = null,
            Volume = 0
        };
        var buyOrderResponse = await _krakenClient.UserTrading().AddOrderAsync(buyOrder);
        return Ok(buyOrderResponse);
    }
}
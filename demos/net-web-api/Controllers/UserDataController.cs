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
        var result = await _krakenClient.UserData.GetAccountBalanceAsync();
        return Ok(result);
    }

    [HttpPost("GetTradeBalance")]
    public async Task<IActionResult> GetTradeBalance(string asset)
    {
        return Ok(await _krakenClient.UserData.GetTradeBalanceAsync(asset));
    }

    [HttpPost("AddOrder")]
    public async Task<IActionResult> AddOrder()
    {
        var buyOrder = new AddOrderRequest
        {
            Pair = "ETHUSD",
            OrderType = "market",
            Type = "buy",
            Volume = 6000,
            OrderFlags = "viqc",
            Validate = true
        };
        var buyOrderResponse = await _krakenClient.UserTrading.AddOrderAsync(buyOrder);
        return Ok(buyOrderResponse);
    }
}
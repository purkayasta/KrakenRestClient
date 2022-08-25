using KrakenClient.Contracts;
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
}
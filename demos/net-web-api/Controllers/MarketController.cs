using KrakenRestClient.Contracts;
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
    public async Task<IActionResult> GetServerTime()
    {
        var serverTime = await this.krakenClient.MarketData.GetServerTimeAsync();
        return Ok(serverTime);
    }

    [HttpGet("AssetInfo")]
    public async Task<IActionResult> GetAssetInfo()
    {
        var assetInfo = await this.krakenClient.MarketData.GetAssetInfoAsync();
        return Ok(assetInfo);
    }

    [HttpGet("AssetInfo/{aclass}/{assetname}")]
    public async Task<IActionResult> GetAssetInfo(string aclass, string assetname)
    {
        var assetInfo = await this.krakenClient.MarketData.GetAssetInfoAsync(assetname, aclass);
        return Ok(assetInfo);
    }

    [HttpGet("TradableAssetPair/")]
    public async Task<IActionResult> GetTradableAssetPair(string assetPair)
    {
        var pairResults = await this.krakenClient.MarketData.GetTradableAssetPairAsync(assetPair);
        return Ok(pairResults);
    }

    [HttpGet("TickerPrice")]
    public async Task<IActionResult> GetTickerPrice(string pair)
    {
        var result = await this.krakenClient.MarketData.GetTickerInformationAsync(pair);
        return Ok(result);
    }

    [HttpGet("OHLCData")]
    public async Task<IActionResult> GetOhlcData(string pair)
    {
        var data = await this.krakenClient.MarketData.GetOhlcDataAsync(pair);
        return Ok(data);
    }

    [HttpGet("Orderbook")]
    public async Task<IActionResult> GetOrderBookAsync(string pair)
    {
        var data = await this.krakenClient.MarketData.GetOrderBookAsync(pair);
        return Ok(data);
    }

    [HttpGet("RecentTrade")]
    public async Task<IActionResult> GetRecentTradeAsync(string pair)
    {
        return Ok(await this.krakenClient.MarketData.GetRecentTradesAsync(pair));
    }
}
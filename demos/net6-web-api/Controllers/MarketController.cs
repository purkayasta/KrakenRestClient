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
    public async Task<IActionResult> GetServerTime()
    {
        var serverTime = await this.krakenClient.MarketData().GetServerTime();
        return Ok(serverTime);
    }

    [HttpGet("AssetInfo")]
    public async Task<IActionResult> GetAssetInfo()
    {
        var assetInfo = await this.krakenClient.MarketData().GetAssetInfo();
        return Ok(assetInfo);
    }

    [HttpGet("AssetInfo/{aclass}/{assetname}")]
    public async Task<IActionResult> GetAssetInfo(string aclass, string assetname)
    {
        var assetInfo = await this.krakenClient.MarketData().GetAssetInfo(assetname, aclass);
        return Ok(assetInfo);
    }

    [HttpGet("TradableAssetPair/")]
    public async Task<IActionResult> GetTradableAssetPair(string assetPair)
    {
        var pairResults = await this.krakenClient.MarketData().GetTradableAssetPair(assetPair);
        return Ok(pairResults);
    }

    [HttpGet("TickerPrice")]
    public async Task<IActionResult> GetTickerPrice(string pair)
    {
        var result = await this.krakenClient.MarketData().GetTickerInformation(pair);
        return Ok(result);
    }
}
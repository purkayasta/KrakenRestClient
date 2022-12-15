﻿using KrakenRestClient.Contracts;
using KrakenRestClient.Models.MarketData;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string RecentSpreadUrl = "Spread";

    public Task<RecentSpreadsResponse?> GetRecentSpreads(string pair, int? since = null)
    {
        ArgumentNullException.ThrowIfNull(pair, nameof(pair));

        _httpClient.BodyParameters.Add("pair", pair);

        if (since is not null) _httpClient.BodyParameters.Add("since", since.Value.ToString());

        return _httpClient.Get<RecentSpreadsResponse>(KrakenConstants.PublicBaseUrl + RecentSpreadUrl);
    }
}

![Kraken Logo](kraken-logo.png)
# KrakenRestClient

> A very minimal, performance c# client library for [kraken crypto exchange](https://www.kraken.com/)

# Usage:

## Instantiation:

### Microsoft DI:

```c#
builder.service.AddKraken("apikey", "secretkey");

public class ApiController {
    private readonly IKrakenClient krakenClient;
    public ApiController(IKrakenClient krakenClient)
        => this.krakenClient = krakenClient;
}
```

### Factory Pattern:

```c#
IKrakenClient krakenClient = KrakenInstaller
    .CreateClient("Your Prefer HTTP Client/ HttpClientFactory", "apikey", "secretkey");
```

### API Example:

1. ServerTime

```c#
ServerTimeResponse serverTime = await this.krakenClient.MarketData.GetServerTimeAsync();
Console.WriteLine(serverTime.Result.UnixTime);
```

2.  TickerInformation (Crypto Prices)
```c#
TickerInformationResponse tickerResponse = await this.krakenClient.MarketData.GetTickerInformationAsync("ETHUSD");
Console.WriteLine(tickerResponse.Result.TodayOpeningPrice);

```

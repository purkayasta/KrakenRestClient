![Kraken Logo](kraken-logo.png)
# KrakenRestClient

> A very minimal, performant c# client library for [kraken crypto exchange](https://www.kraken.com/)

[Download from NUGET](https://www.nuget.org/packages/KrakenRestClient/)

![Nuget Version](https://img.shields.io/nuget/v/KrakenRestClient)
![Download](https://img.shields.io/nuget/dt/KrakenRestClient?color=blue&style=plastic)
![GitHub last commit](https://img.shields.io/github/last-commit/purkayasta/KrakenRestClient)

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

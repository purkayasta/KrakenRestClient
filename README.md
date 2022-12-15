# KrakenRestClient 
> An very minimal, performant c# client library for kraken crypto exchange


[NUGET](https://www.nuget.org/packages/KrakenRestClient/)

![Nuget](https://img.shields.io/nuget/v/KrakenRestClient)
![Download](https://img.shields.io/nuget/dt/KrakenRestClient?color=blue&style=plastic)
![released](https://img.shields.io/github/release-date/purkayasta/KrakenRestClient?style=flat-square)


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
IKrakenClient krakenClient = KrakenFactoryInstaller.CreateClient("Your Prefer HTTP Client/ HttpClientFactory", "apikey", "secretkey");
```


### API Example:
1. ServerTime
```c#
ServerTimeResponse serverTime = await this.krakenClient.MarketData().GetServerTime();
Console.WriteLine(serverTime.Result.UnixTime);
```
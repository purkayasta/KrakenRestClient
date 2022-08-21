using KrakenClient.Models.MarketData;

namespace KrakenClient.Contracts;

public partial interface IMarketDataEndpoint
{
    Task<ServerTime?> GetServerTime();
    
    Task<SystemStatus?> GetSystemStatus();
    
    Task<AssetInfo?> GetAssetInfo();
    Task<AssetInfo?> GetAssetInfo(string asset, string aclass = "currency");
}
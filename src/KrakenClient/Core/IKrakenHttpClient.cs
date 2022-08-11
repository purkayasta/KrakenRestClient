namespace KrakenClient.Core;

public interface IKrakenHttpClient
{
    public Dictionary<string, string>? Headers { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }
    Task<T?> Get<T>(string url) where T : class;
    Task<T?> Post<T>(string url) where T : class;
}
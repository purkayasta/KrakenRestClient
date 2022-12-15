using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace KrakenRestClient.Core;

internal interface IKrakenHttpClient
{
    public Dictionary<string, string> Headers { get; set; }
    public Dictionary<string, string> BodyParameters { get; set; }
    Task<T?> Get<T>(string url) where T : class;
    Task<T?> Post<T>(string url) where T : class;
}
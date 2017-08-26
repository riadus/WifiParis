using System.Threading.Tasks;

namespace WifiParisComplete.Domain.Interfaces
{
    public interface IApiClient
    {
		Task<T> GetAsync<T>(string url);
		Task<TResponse> PostAsync<TResponse, TContent>(string url, TContent content);
        bool IsLocal { get; }
    }
}

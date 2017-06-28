using System.Threading.Tasks;

namespace WifiParisComplete.Domain.Interfaces
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string url);
    }
}

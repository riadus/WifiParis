using System.Net.Http;

namespace WifiParisComplete.Domain
{
    public interface IMessageHandlerProvider
    {
        HttpMessageHandler NativeHandler { get; }
    }
}

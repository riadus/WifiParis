using System.Net.Http;
using WifiParisComplete.Domain;

namespace WifiParisMVCComplete.iOS
{
    public class MessageHandlerProviderIOS : IMessageHandlerProvider
    {
        public HttpMessageHandler NativeHandler => new NSUrlSessionHandler { DisableCaching = true };
    }
}

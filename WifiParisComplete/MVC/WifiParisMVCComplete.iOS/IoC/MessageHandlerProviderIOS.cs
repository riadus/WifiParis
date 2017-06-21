using System.Net.Http;
using WifiParisComplete.Domain;
using WifiParisComplete.Domain.Attributes;

namespace WifiParisMVCComplete.iOS
{
    [RegisterInterfaceAsDynamic]
    public class MessageHandlerProviderIOS : IMessageHandlerProvider
    {
        public HttpMessageHandler NativeHandler => new NSUrlSessionHandler { DisableCaching = true };
    }
}

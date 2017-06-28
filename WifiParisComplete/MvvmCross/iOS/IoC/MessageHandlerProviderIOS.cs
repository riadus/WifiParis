using System;
using System.Net.Http;
using WifiParisComplete.Domain;

namespace WifiParisComplete.iOS
{
    public class MessageHandlerProviderIOS : IMessageHandlerProvider
    {
        public HttpMessageHandler NativeHandler => new NSUrlSessionHandler { DisableCaching = true };
    }
}

using System.Net.Http;
using WifiParisComplete.Domain;
using Xamarin.Android.Net;

namespace WifiParisComplete.Droid
{
    public class MessageHandlerProviderDroid : IMessageHandlerProvider
    {
        public HttpMessageHandler NativeHandler => new AndroidClientHandler();
    }
}

using System.Net.Http;
using WifiParisComplete.Domain;
using Xamarin.Android.Net;
using WifiParisComplete.Domain.Attributes;

namespace WifiParisMVCComplete.Droid
{
    [RegisterInterfaceAsDynamic]
    public class MessageHandlerProviderDroid : IMessageHandlerProvider
    {
        public HttpMessageHandler NativeHandler => new AndroidClientHandler();
    }
}

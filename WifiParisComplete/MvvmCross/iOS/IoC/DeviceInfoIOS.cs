using WifiParisComplete.Services;

namespace WifiParisComplete.iOS.IoC
{
    public class DeviceInfoIOS : IDeviceInfo
    {
        public DevicePlatform Brand => DevicePlatform.iOS;
    }
}

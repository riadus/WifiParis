using System;
using WifiParisComplete.Services;

namespace WifiParisComplete.Droid.IoC
{
    public class DeviceInfoDroid : IDeviceInfo
    {
        public DevicePlatform Brand => DevicePlatform.Android;
    }
}

using System;
namespace WifiParisComplete.Services
{
    public interface IDeviceInfo
    {
        DevicePlatform Brand { get; }
    }

    public enum DevicePlatform
    {
        Android,
        iOS
    }
}

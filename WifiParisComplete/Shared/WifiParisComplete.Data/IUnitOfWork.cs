using System;
namespace WifiParisComplete.Data
{
    public interface IUnitOfWork
    {
        IRepository<WifiHotspot> WifiHotspotRepository { get; }
    }
}

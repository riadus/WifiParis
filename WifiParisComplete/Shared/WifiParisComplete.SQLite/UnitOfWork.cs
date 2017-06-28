using System;
using System.Collections.Generic;
using System.Linq;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.Attributes;

namespace WifiParisComplete.SqLite
{
    [RegisterInterfaceAsLazySingleton]
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork ()
        {
            AddressRepository = new Repository<Address> ();
            CoordinatesRepository = new Repository<Coordinates> ();
            WifiHotspotRepository = new Repository<WifiHotspot> ();
        }

        public IRepository<Address> AddressRepository { get; }
        public IRepository<Coordinates> CoordinatesRepository { get; }
        public IRepository<WifiHotspot> WifiHotspotRepository { get; }

        public void SaveWifiHotspots  (IEnumerable<WifiHotspot> wifiHotspots)
        {
            WifiHotspotRepository.Save (wifiHotspots);
            foreach (var wifiHotspot in wifiHotspots) {
                wifiHotspot.Address.WifiHotspotId = wifiHotspot.Id;
                wifiHotspot.Coordinates.WifiHotspotId = wifiHotspot.Id;
            }

            CoordinatesRepository.Save (wifiHotspots.Select (x => x.Coordinates));
            AddressRepository.Save (wifiHotspots.Select (x => x.Address));
        }

        public void DeleteAllWifiHotspots ()
        {
            CoordinatesRepository.DeleteAll ();
            AddressRepository.DeleteAll ();
            WifiHotspotRepository.DeleteAll ();
        }

        public IEnumerable<WifiHotspot> GetAllWifiHotspots ()
        {
            return WifiHotspotRepository.GetAll ();
        }
    }
}
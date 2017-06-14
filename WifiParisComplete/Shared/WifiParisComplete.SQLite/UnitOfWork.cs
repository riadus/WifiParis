using WifiParisComplete.Data;
using WifiParisComplete.Domain.Attributes;

namespace WifiParisComplete.SqLite
{
    [RegisterInterfaceAsLazySingleton]
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork ()
        {
            WifiHotspotRepository = new Repository<WifiHotspot> (SQLiteDatabase.GetConnection ());
        }

        public IRepository<WifiHotspot> WifiHotspotRepository { get; }
    }
}
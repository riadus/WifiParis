using System.Collections.Generic;

namespace WifiParisComplete.Data
{
    public interface IRepository<T> where T : new()
    {
        IEnumerable<T> GetAll ();
        void Save (IEnumerable<T> items);
        int DeleteAll ();
    }
}

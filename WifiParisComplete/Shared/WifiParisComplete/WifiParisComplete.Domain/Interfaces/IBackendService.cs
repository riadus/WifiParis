using System.Collections.Generic;
using System.Threading.Tasks;
using WifiParisComplete.Domain.API;

namespace WifiParisComplete.Domain.Interfaces
{
    public interface IBackendService
    {
		Task<List<Record>> GetRecords();
		Task<List<Record>> GetMoreRecords(int lastId);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WifiParisComplete.Domain.API;
using WifiParisComplete.Domain.Attributes;
using WifiParisComplete.Domain.Interfaces;

namespace WifiParisComplete.Domain.Services
{
    [RegisterInterfaceAsDynamic]
    public class BackendService : IBackendService
    {
        private IApiClient ApiClient { get; }

        public BackendService (IApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        public async Task<List<Record>> GetMoreRecords(int lastId)
        {
            var records = await ApiClient.GetAsync<List<Record>> ($"?dataset=liste-des-antennes-wifi&start={lastId}");
            return records;
        }

        public async Task<List<Record>> GetRecords()
        {
            var rootObject = await ApiClient.GetAsync<RootObject> ("?dataset=liste-des-antennes-wifi");
            return rootObject.Records;
        }
    }
}

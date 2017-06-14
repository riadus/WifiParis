using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WifiParisComplete.Domain.Attributes;
using WifiParisComplete.Domain.Interfaces;

namespace WifiParisComplete.Domain.Services
{
    [RegisterInterfaceAsDynamic]
    public class ApiClient : IApiClient
    {
        private HttpClient HttpClient { get; }
        private const string BaseAddress = "https://opendata.paris.fr/api/records/1.0/search/?dataset=liste-des-antennes-wifi";
        public ApiClient()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseAddress)
            };
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var request = new HttpRequestMessage (HttpMethod.Get, url);
            //request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try{
                var response = await HttpClient.SendAsync (request).ConfigureAwait (false);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync ();
                    var deserializedObject = JsonConvert.DeserializeObject<T> (content);
                    return deserializedObject;
                }
                throw new Exception ("Something wrong happened with the API");
            }
            catch (TaskCanceledException tce)
            {
                Debug.WriteLine($"request {url} timed out");
                throw new HttpRequestException ("Request timed out", tce);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HttpClient Get request {url} exception {ex}");
                throw;
            }
        }
    }
}

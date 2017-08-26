using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public bool IsLocal => true;
		private const string LocalAddress = "http://192.168.178.13:3000/records";
		private const string RemoteAddress = "https://opendata.paris.fr/api/records/1.0/search/";

        private string BaseAddress => IsLocal ? LocalAddress : RemoteAddress;
       
        public ApiClient(IMessageHandlerProvider messageHandlerProvider)
        {
            HttpClient = new HttpClient(messageHandlerProvider.NativeHandler)
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

        public async Task<TResponse> PostAsync<TResponse, TContent>(string url, TContent content)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var contentSerialized = JsonConvert.SerializeObject(content);
                request.Content = new StringContent(contentSerialized);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var deserializedResponse = JsonConvert.DeserializeObject<TResponse>(responseContent);
                    return deserializedResponse;
                }
                throw new Exception("Something wrong happened with the API");
            }
			catch (TaskCanceledException tce)
			{
				Debug.WriteLine($"request {url} timed out");
				throw new HttpRequestException("Request timed out", tce);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"HttpClient Get request {url} exception {ex}");
				throw;
			}
        }
    }
}

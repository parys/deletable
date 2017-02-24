using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using DeletableExample.Contracts;
using Newtonsoft.Json;

namespace DeletableExample
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private const string BaseAddress = "http://mylfc.azurewebsites.net/api/v1/";
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string address) where T : class
        {
            var uri = new Uri(BaseAddress + address);
            try
            {
                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ABCRestaurant.Web
{
    public class HttpClient : IHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string Apiurl = "http://localhost:32273/";
        public HttpClient(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<List<T>> GetListAsync<T>(string api)
        {
            var client = _httpClientFactory.CreateClient();
            var ListItem = await client.GetAsync(Apiurl+api);
            List<T> ModelList = null;
            if (ListItem.IsSuccessStatusCode)
            {
                ModelList = await ListItem.Content.ReadAsAsync<List<T>>();
            }
            return ModelList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ABCRestaurant.Web.Models;

namespace ABCRestaurant.Web.BusinessClass
{
    public class MenuService : IMenuService
    {
        private readonly IHttpClientFactory _clientFactory;
        public MenuService(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }
        public async Task<Menu> GetMenuByIdAsync(string ID)
        {
            Menu menu = null;
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Menu/" + ID);
            var client = _clientFactory.CreateClient("ABCRestaurantApi");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                menu = await response.Content.ReadAsAsync<Menu>();
            }
            return menu;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ABCRestaurant.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCRestaurant.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public MenuController(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<Menu> menuList = null;
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Menu");
            var client = _clientFactory.CreateClient("ABCRestaurantApi");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                menuList = await response.Content.ReadAsAsync<List<Menu>>();
            }
            return View(menuList);
        }
    }
}
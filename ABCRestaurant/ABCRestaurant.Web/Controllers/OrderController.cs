using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ABCRestaurant.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCRestaurant.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public OrderController(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index(string ID)
        {
            Menu menu = null;
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Menu/"+ID);
            var client = _clientFactory.CreateClient("ABCRestaurantApi");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                menu = await response.Content.ReadAsAsync<Menu>();
            }
            return View(menu);
        }

        public IActionResult checkout()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCRestaurant.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCRestaurant.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpClient _httpClient;
        public OrderController(IHttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IActionResult> Index(string ID)
        {
            Menu menuList = await _httpClient.GetByIdAsync<Menu>(ID,"api/Menu");
            return View(menuList);
        }
    }
}
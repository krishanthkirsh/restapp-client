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
        private readonly IHttpClient _httpClient;
        public MenuController(IHttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            List<Menu> menuList = await _httpClient.GetListAsync<Menu>("api/Menu");
            return View(menuList);
        }
    }
}
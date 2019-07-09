using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCRestaurant.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCRestaurant.Web.Controllers
{
    public class MenuController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<User> claimTerms = await HttpHelper.Get<List<User>>("/api/User/");
            return View();
        }
    }
}
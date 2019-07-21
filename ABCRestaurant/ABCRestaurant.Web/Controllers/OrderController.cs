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
        public IActionResult Index(string ID)
        {
            return View();
        }
    }
}
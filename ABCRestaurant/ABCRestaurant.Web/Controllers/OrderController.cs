using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ABCRestaurant.Web.BusinessClass;
using ABCRestaurant.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCRestaurant.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IUserInterface _userInterface;
        private readonly IOrderService _orderService;
        public OrderController(IMenuService menuService, IUserInterface userInterface, IOrderService orderService)
        {
            this._menuService = menuService;
            this._userInterface = userInterface;
            this._orderService = orderService;
        }
        public async Task<IActionResult> Index(string ID)
        {

            List<User> users = await _userInterface.GetUserListAsync();
            Menu menu = await _menuService.GetMenuByIdAsync(ID);
            ViewModel viewModel = new ViewModel
            {
                MenuModel = menu,
                UserList = users
            };

            return View(viewModel);
        }

        public async Task<IActionResult> checkout(string menu, string UserId)
        {
            Menu menuobj = await _menuService.GetMenuByIdAsync(menu);
            User user = await _userInterface.GetUserByIdAsync(UserId);
            Order order = new Order
            {
                Menu = menuobj,
                User = user
            };
            return View(order);
        }

        public async Task<JsonResult> OrderNow(string UserId, string menu, string Date)
        {
            Order order = new Order
            {
                OrderDate = Date,
                MenuId = Convert.ToInt32(menu),
                UserId = Convert.ToInt32(UserId)
            };
            string message = await _orderService.AddOrder(order);
            return Json(message);
        }
    }
}
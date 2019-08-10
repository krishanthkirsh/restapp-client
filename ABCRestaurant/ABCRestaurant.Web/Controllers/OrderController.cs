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
        public OrderController(IMenuService menuService, IUserInterface userInterface)
        {
            this._menuService = menuService;
            this._userInterface = userInterface;
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

        public IActionResult checkout()
        {
            return View();
        }

        public ErrorViewModel OrderNow(string UserId, string menu)
        {
            ErrorViewModel model = null;
            return model;
        }
    }
}
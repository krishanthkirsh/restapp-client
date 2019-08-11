using ABCRestaurant.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCRestaurant.Web.BusinessClass
{
    public interface IOrderService
    {
        Task<string> AddOrder(Order viewModel);
    }
}

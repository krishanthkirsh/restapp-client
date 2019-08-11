using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ABCRestaurant.Web.Models;
using Newtonsoft.Json;

namespace ABCRestaurant.Web.BusinessClass
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory _clientFactory;

        public OrderService(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }
        public async Task<string> AddOrder(Order viewModel)
        {
            string successMessage = "";
            var request = new HttpRequestMessage(HttpMethod.Post, "api/Order/");
            var json = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = stringContent;
            var client = _clientFactory.CreateClient("ABCRestaurantApi");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                successMessage = "Successfuly Added";
            }
            return successMessage;
        }
    }
}

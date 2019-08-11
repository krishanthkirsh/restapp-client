using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ABCRestaurant.Web.Models;

namespace ABCRestaurant.Web.BusinessClass
{
    public class UserService : IUserInterface
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserService(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        public async Task<User> GetUserByIdAsync(string Id)
        {
            User users = null;
            var request = new HttpRequestMessage(HttpMethod.Get, "api/User/"+Id);
            var client = _clientFactory.CreateClient("ABCRestaurantApi");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<User>();
            }
            return users;
        }

        public async Task<List<User>> GetUserListAsync()
        {
            List<User> users = null;
            var request = new HttpRequestMessage(HttpMethod.Get, "api/User");
            var client = _clientFactory.CreateClient("ABCRestaurantApi");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }
            return users;
        }
    }
}

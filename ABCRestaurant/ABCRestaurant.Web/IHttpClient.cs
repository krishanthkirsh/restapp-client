using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCRestaurant.Web
{
    public interface IHttpClient
    {
        Task<List<T>> GetListAsync<T>(string api);
    }
}

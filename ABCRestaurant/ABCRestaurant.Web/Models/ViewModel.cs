using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCRestaurant.Web.Models
{
    public class ViewModel
    {
        public virtual IEnumerable<User> UserList { get; set; }
        public virtual Menu MenuModel { get; set; }
    }
}

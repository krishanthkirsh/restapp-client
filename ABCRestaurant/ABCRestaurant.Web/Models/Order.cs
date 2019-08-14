using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCRestaurant.Web.Models
{
    public class Order 
        :Entity<int>
    {
        public string OrderDate { get; set; }
        public int? MenuId { get; set; }
        public int? UserId { get; set; }
        public Menu Menu { get; set; }
        public User User { get; set; }
    }
}

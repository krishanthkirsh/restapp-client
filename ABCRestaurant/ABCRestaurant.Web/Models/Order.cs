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
        public virtual Menu MenuItem { get; set; }
        public virtual User ProfileUser { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCRestaurant.Web.Models
{
    public class User : Entity<int>
    {
        public string UserName { get; set; }
    }
}

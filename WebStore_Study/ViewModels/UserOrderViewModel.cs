﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_Study.ViewModels
{
    public class UserOrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal TotalSum { get; set; }
    }
}

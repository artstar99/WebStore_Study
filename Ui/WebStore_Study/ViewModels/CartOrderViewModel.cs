using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_Study.ViewModels
{
    public class CartOrderViewModel
    {
        public CartViewModel Cart { get; set; }
        public OrderViewModel Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.Components
{
    public class CartViewComponent:ViewComponent
    {
        private readonly ICartService cartService;

        public CartViewComponent(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartService.TransformFromCart();
            return View(cart);
        }
    }
}

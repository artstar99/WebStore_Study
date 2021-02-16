using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Mapping;

namespace WebStore_Study.Services.Products
{
    public class CartService:ICartService
    {
        private readonly IProductData productData;
        private readonly ICartStore cartStore;

        public CartService(IProductData productData, ICartStore cartStore)
        {
            this.productData = productData;
            this.cartStore = cartStore;
           }

       



        public void AddToCart(int id)
        {
            var cart = cartStore.Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null)
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            else
                item.Quantity++;
            cartStore.Cart = cart;

        }

        public void DecrementFromCart(int id)
        {
            var cart = cartStore.Cart;
            var item = cart.Items.FirstOrDefault(item => item.ProductId == id);
            if (item is null) return;

            if (item.Quantity > 0)
                item.Quantity--;

            if (item.Quantity == 0)
                cart.Items.Remove(item);


            cartStore.Cart = cart;
        }

        public void RemoveFromCart(int id)
        {
            var cart = cartStore.Cart;
            var item = cart.Items.FirstOrDefault(item => item.ProductId == id);
            if (item is null) return;

            cart.Items.Remove(item);

            cartStore.Cart = cart;
        }

        public void Clear()
        {
            var cart = cartStore.Cart;
            cart.Items.Clear();
            cartStore.Cart = cart;
        }

        public CartViewModel TransformFromCart()
        {
            var products = productData.GetProducts(new ProductFilter
            {
                Ids = cartStore.Cart.Items.Select(item => item.ProductId).ToArray()
            });
            var productViewModels = products.Products.FromDto().ToView().ToDictionary(p => p.Id);
            return new CartViewModel
            {
                Items = cartStore.Cart.Items.Select(item => (productViewModels[item.ProductId], item.Quantity))
            };
        }

    }
}

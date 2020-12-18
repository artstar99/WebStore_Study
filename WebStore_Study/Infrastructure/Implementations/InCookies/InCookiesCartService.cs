using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;
using WebStore_Study.Infrastructure.Mapping;
using WebStore_Study.ViewModels;

namespace WebStore_Study.Infrastructure.Implementations.InCookies
{
    public class InCookiesCartService:ICartService
    {
        private readonly IProductData productData;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string cartName;

        public InCookiesCartService(IProductData productData, IHttpContextAccessor httpContextAccessor)
        {
            this.productData = productData;
            this.httpContextAccessor = httpContextAccessor;
            var user = httpContextAccessor.HttpContext!.User;
            var userName = user.Identity!.IsAuthenticated ? $"-{user.Identity.Name!.Replace('@', '&')}" : @"-Anonimous";
            cartName = $"WebStore.Cart{userName}";
        }
        
        private Cart Cart
        {
            get
            {
                var context = httpContextAccessor.HttpContext;
                var cookies = context.Response.Cookies;
                var cartCookie = context.Request.Cookies[cartName];
                if (cartCookie is null)
                {
                    var cart = new Cart();
                    cookies.Append(cartName, JsonConvert.SerializeObject(cart));
                    return cart;
                }
                ReplaceCookies(cookies, cartCookie);
                return JsonConvert.DeserializeObject<Cart>(cartCookie);

            }
            set => ReplaceCookies(httpContextAccessor.HttpContext!.Response.Cookies,
                JsonConvert.SerializeObject(value));
        }

        private void ReplaceCookies(IResponseCookies cookies, string cookie)
        {
            cookies.Delete(cartName);
            cookies.Append(cartName, cookie);
        }

        public void AddToCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null)
                cart.Items.Add(new CartItem {ProductId = id, Quantity = 1});
            else
                item.Quantity++;
            Cart = cart;

        }

        public void DecrementFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(item => item.ProductId == id);
            if (item is null) return;

            if (item.Quantity > 0)
                item.Quantity--;

            if (item.Quantity == 0)
                cart.Items.Remove(item);
            
           
            Cart = cart;
        }

        public void RemoveFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(item => item.ProductId == id);
            if (item is null) return;

            cart.Items.Remove(item);

            Cart = cart;
        }

        public void Clear()
        {
            var cart = Cart;
            cart.Items.Clear();
            Cart = cart;
        }

        public CartViewModel TransformFromCart()
        {
            var products = productData.GetProducts(new ProductFilter
            {
                Ids = Cart.Items.Select(item=>item.ProductId).ToArray()

            });
            var productViewModels = products.ToView().ToDictionary(p=>p.Id);
            return new CartViewModel
            {
                Items = Cart.Items.Select(item => (productViewModels[item.ProductId], item.Quantity))
            };
        }
    }
}

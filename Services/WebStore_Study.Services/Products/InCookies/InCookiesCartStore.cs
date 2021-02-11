using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.Services.Products.InCookies
{
    public class InCookiesCartStore:ICartStore
    {

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string cartName;
        public InCookiesCartStore(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            var user = httpContextAccessor.HttpContext!.User;
            var userName = user.Identity!.IsAuthenticated ? $"-{user.Identity.Name!.Replace('@', '&')}" : @"-Anonimous";
            cartName = $"WebStore.Cart{userName}";
        }


        public Cart Cart
        {
            get
            {
                var context = httpContextAccessor.HttpContext;
                var cookies = context.Response.Cookies; // Кука которая уйдет клиенту
                var cartCookie = context.Request.Cookies[cartName]; // Запрашиваемая кука у клиента
                if (cartCookie is null)
                {

                    var cart = new Cart();
                    cookies.Append(cartName, JsonConvert.SerializeObject(cart));
                    return cart;
                }
                //ReplaceCookies(cookies, cartCookie);
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




    }
}

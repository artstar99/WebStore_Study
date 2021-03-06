﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Services.Products.InCookies
{
    public class InCookiesRecentlyViewedService
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly string cookieName;


        public InCookiesRecentlyViewedService(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
            var user = contextAccessor.HttpContext!.User;
            var userName = user.Identity!.IsAuthenticated ? $"-{user.Identity.Name!.Replace('@', '&')}" : "-Anonimous";
            cookieName = $"RecentlyViewed{userName}";
        }

        public List<ProductViewModel> RecentlyViewed
        {
            get
            {
                var context = contextAccessor.HttpContext;
                var cookies = context.Request.Cookies;
                if (cookies.ContainsKey(cookieName))
                {

                }
                return null;

            }
            set
            {
                RecentlyViewed = value;

            }
        }
        public void AddToRecentlyViewed(ProductViewModel model)
        {

        }
    }
}

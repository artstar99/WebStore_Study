using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebStore_Study.DAL.Context;
using WebStore_Study.Infrastructure.Implementations;
using WebStore_Study.Infrastructure.Interfaces;

namespace WebStore_Study.Infrastructure
{
    public static class UserServicesInjection
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeesData, InMemeoryEmplyeesData>();
            services.AddTransient<IBlogService, InmemoryBlogService>();
            services.AddTransient<IProductData, InmemeoryProductData>();
           
            return services;
        }

    }
}

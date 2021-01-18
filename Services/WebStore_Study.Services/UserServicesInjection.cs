using Microsoft.Extensions.DependencyInjection;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Data;
using WebStore_Study.Services.Products.InCookies;
using WebStore_Study.Services.Products.InSQL;

namespace WebStore_Study.Services
{
    public static class UserServicesInjection
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddTransient<IUsersData, SqlEmployeeData>();
            services.AddTransient<IBlogService, SqlBlogData>();
            services.AddTransient<IProductData, SqlProductData>();
            services.AddTransient<WebStore_StudyDbInitializer>();
            services.AddScoped<ICartService, InCookiesCartService>();

            services.AddScoped<IOrderService, SqlOrderService>();
            return services;
        }

    }
}

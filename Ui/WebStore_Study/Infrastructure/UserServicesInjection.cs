using Microsoft.Extensions.DependencyInjection;
using WebStore_Study.Data;
using WebStore_Study.Infrastructure.Implementations.InCookies;
using WebStore_Study.Infrastructure.Implementations.InSQL;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.Infrastructure
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

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebStore_Study.Clients.Identity;
using WebStore_Study.Clients.Orders;
using WebStore_Study.Clients.Products;
using WebStore_Study.Clients.Values;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Interfaces.TestApi;
using WebStore_Study.Services.Data;
using WebStore_Study.Services.Products.InCookies;
using WebStore_Study.Services.Products.InSQL;

namespace WebStore_Study
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddRazorRuntimeCompilation();


            services.AddTransient<IUsersData, SqlEmployeeData>();
            services.AddTransient<IBlogService, SqlBlogData>();
            services.AddScoped<ICartService, InCookiesCartService>();
            
            services.AddTransient<IProductData, ProductsClient>();
            services.AddScoped<IOrderService, OrdersClient>();
            services.AddScoped<IValuesService, ValuesClient>();

            #region Identity
            services.AddIdentity<User, Role>()
            .AddIdentityWebApiClients()
            .AddDefaultTokenProviders(); 
            #endregion

            #region База данных
            services.AddTransient<WebStore_StudyDbInitializer>();
            services.AddDbContext<WebStore_StudyDb>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default"))); 
            #endregion

            services.AddHttpClient();

            services.Configure<IdentityOptions>(opt =>
            {
#if DEBUG
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredUniqueChars = 3; 
#endif
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@.";
                opt.Lockout.AllowedForNewUsers = false;
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "WebStoreStudyKostyaKobetskoy";
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);
                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";
                opt.AccessDeniedPath = "/Account/AccessDenied";
                opt.SlidingExpiration = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStore_StudyDbInitializer db)
        {
            db.Initialize();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );


                //endpoints.MapGet("/greetings", async context =>{await context.Response.WriteAsync(configuration["greetings"]);});
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

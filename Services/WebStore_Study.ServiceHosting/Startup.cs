using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebStore_Study.Clients.Values;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Interfaces.TestApi;
using WebStore_Study.Services.Data;
using WebStore_Study.Services.Products.InCookies;
using WebStore_Study.Services.Products.InSQL;

namespace WebStore_Study.ServiceHosting
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebStore_StudyDb>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddTransient<WebStore_StudyDbInitializer>();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<WebStore_StudyDb>()
                .AddDefaultTokenProviders();



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

            services.AddTransient<IUsersData, SqlEmployeeData>();
            services.AddTransient<IBlogService, SqlBlogData>();
            services.AddTransient<IProductData, SqlProductData>();
            services.AddScoped<ICartService, InCookiesCartService>();

            services.AddScoped<IOrderService, SqlOrderService>();
            services.AddScoped<IValuesService, ValuesClient>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebStore_Study.ServiceHosting", Version = "v1" });
            });






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebStore_Study.ServiceHosting v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

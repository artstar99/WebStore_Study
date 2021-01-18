using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain.Entities;

// ReSharper disable All

namespace WebStore_Study.Data
{
    public class WebStore_StudyDbInitializer
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly WebStore_StudyDb dbContext;
        private readonly ILogger<WebStore_StudyDbInitializer> logger;

        public WebStore_StudyDbInitializer(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            WebStore_StudyDb dbContext,
            ILogger<WebStore_StudyDbInitializer> logger)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public void Initialize()
        {
            logger.LogInformation("Инициализация БД...");

            var db = dbContext.Database;
            if (db.GetPendingMigrations().Any())
            {
                logger.LogInformation("Есть непримененные миграции...");
                db.Migrate();
                logger.LogInformation("Миграции выполнены успешно...");
            }
            else
            {
                logger.LogInformation("Структура БД в актуальном состоянии...");
            }

            //Инициализация товаров
            try
            {
                logger.LogInformation("Начало инициализации данных...");
                InitializeProducts();
                logger.LogInformation("Инициализация данных прошла успешно...");
            }
            catch (Exception e)
            {
                logger.LogInformation("ОШИБКА!!! " + e.Message);
            }


            //Инициализация данных блогов
            try
            {
                logger.LogInformation("Начало инициализации данных блогов...");
                InitializeBlogs();
                logger.LogInformation("Инициализация данных блогов прошла успешно...");
            }
            catch (Exception e)
            {
                logger.LogInformation("ОШИБКА!!! " + e.Message);
            }

            //Инициализация Identity
            try
            {
                InitializeIdentityAsync().Wait();
            }
            catch (Exception e)
            {
                logger.LogError(e, "Ошибка при инициализации БД системы Identity");
                throw;
            }


        }

        private void InitializeBlogs()
        {
            if (dbContext.Blogs.Any())
            {
                return;
            }
            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Blogs] ON");
                dbContext.Blogs.AddRange(TestData.Blogs);
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Blogs] OFF");
                dbContext.Database.CommitTransaction();
            }   
        }

        //private void InitializeUsers()
        //{
        //    if (dbContext.Users.Any())
        //    {
        //        return;
        //    }
        //    using (dbContext.Database.BeginTransaction())
        //    {
        //        dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Users] ON");
        //        dbContext.Users.AddRange(TestData.Users);
        //        dbContext.SaveChanges();
        //        dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Users] OFF");
        //        dbContext.Database.CommitTransaction();
        //    }
        //}

        private void InitializeProducts()
        {
            if (dbContext.Products.Any())
            {
                return;
            }
            logger.LogInformation("Добавление исходных данных в таблицу...");
            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] ON");
                dbContext.Sections.AddRange(TestData.Sections);
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] OFF");
                dbContext.Database.CommitTransaction();
            }

            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] ON");
                dbContext.Brands.AddRange(TestData.Brands);
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] OFF");
                dbContext.Database.CommitTransaction();
            }

            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                dbContext.Products.AddRange(TestData.Products);
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");
                dbContext.Database.CommitTransaction();
            }



        }

        private async Task InitializeIdentityAsync()
        {
            async Task CheckRole(string roleName)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new Role { Name = roleName });
                }
            }
            
            await CheckRole(Role.Administrator);
            await CheckRole(Role.User);

            if (await userManager.FindByEmailAsync("Admin@gmail.com") is null)
            {
                var admin = new User()
                {
                    FirstName = "Administrator",
                    LastName = "Administrator",
                    Email = "Admin@gmail.com",
                    UserName = "Admin@gmail.com"
                };
                var creationResult = await userManager.CreateAsync(admin, User.DefaultAdminPassword);
                if (creationResult.Succeeded)
                {
                    var result = await userManager.AddToRoleAsync(admin, Role.Administrator);
                    if (!result.Succeeded)
                        logger.LogError("не добавилась связь роли администратора с учетной записью");
                }
                else
                {
                    var errors = creationResult.Errors.Select(e => e.Description);
                    throw new InvalidOperationException(
                        $"Ошибка при создании учетной записи администратора{string.Join(',', errors)}");
                }

               
            }
           
        }

        private async Task SetAdminRole(User user)
        {
            var result = await userManager.AddToRoleAsync(user, Role.Administrator);
            if (!result.Succeeded)
            {
                logger.LogError("Ошибка при создании связи учетной записи администратора и роли");
            }
        }
        //private async Task CheckRole(string roleName)
        //{
        //    if (!await roleManager.RoleExistsAsync(roleName))
        //    {
        //        await roleManager.CreateAsync(new Role { Name = roleName });
        //    }
        //}
    }
}

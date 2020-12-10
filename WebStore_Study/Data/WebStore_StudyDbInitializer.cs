using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore_Study.DAL.Context;
// ReSharper disable All

namespace WebStore_Study.Data
{
    public class WebStore_StudyDbInitializer
    {
        private readonly WebStore_StudyDb dbContext;
        private readonly ILogger<WebStore_StudyDbInitializer> logger;

        public WebStore_StudyDbInitializer(WebStore_StudyDb dbContext, ILogger<WebStore_StudyDbInitializer> logger)
        {
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

            try
            {
                logger.LogInformation("Начало инициализации данных...");
                InitializeData();
                logger.LogInformation("Инициализация данных прошла успешно...");
            }
            catch (Exception e)
            {
                logger.LogInformation("ОШИБКА!!! "+e.Message);
            }
            
            
        }

        private void InitializeData()
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

            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Blogs] ON");
                dbContext.Blogs.AddRange(TestData.Blogs);
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Blogs] OFF");
                dbContext.Database.CommitTransaction();
            }

        }
    }
}

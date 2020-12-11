﻿using System;
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

            //Инициализация товаров
            try
            {
                logger.LogInformation("Начало инициализации данных...");
                InitializeProducts();
                logger.LogInformation("Инициализация данных прошла успешно...");
            }
            catch (Exception e)
            {
                logger.LogInformation("ОШИБКА!!! "+e.Message);
            }

            //Инициализация данных о сотрудниках
            try
            {
                logger.LogInformation("Начало инициализации данных о сотрудниках...");
                InitializeUsers();
                logger.LogInformation("Инициализация данных о сотрудниках прошла успешно...");
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

        private void InitializeUsers()
        {
            if (dbContext.Users.Any())
            {
                return;
            }
            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Users] ON");
                dbContext.Users.AddRange(TestData.Users);
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Users] OFF");
                dbContext.Database.CommitTransaction();
            }
        }

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
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.DAL.Context
{
    public class WebStore_StudyDb:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Section> Sections { get; set; }

        public WebStore_StudyDb(DbContextOptions<WebStore_StudyDb> options) :base(options) {}

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            
        }
    }
}

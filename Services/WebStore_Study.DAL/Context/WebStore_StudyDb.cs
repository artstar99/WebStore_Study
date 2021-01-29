using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Domain.Entities.Orders;

namespace WebStore_Study.DAL.Context
{
    public class WebStore_StudyDb : IdentityDbContext<User, Role, string>
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Section> Sections { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        //public DbSet<OrderItem> OrderItems { get; set; }


        public WebStore_StudyDb(DbContextOptions<WebStore_StudyDb> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }
    }
}

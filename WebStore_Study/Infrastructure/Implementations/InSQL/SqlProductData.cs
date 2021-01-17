using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;

namespace WebStore_Study.Infrastructure.Implementations.InSQL
{
    public class SqlProductData : IProductData
    {
        private readonly WebStore_StudyDb dbContext;

        public SqlProductData(WebStore_StudyDb dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Brand> GetBrands() => dbContext.Brands.Include(b=>b.Products);

        public IEnumerable<Section> GetSections() => dbContext.Sections;

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            IQueryable<Product> query = dbContext.Products
                .Include(p=>p.Brand)
                .Include(p=>p.Section);
            
            if (filter?.Ids!=null && filter?.Ids.Length >0)
            {
                query = query.Where(prod => filter.Ids.Contains(prod.Id));
            }
            else
            {
                if (filter?.BrandId != null)
                    query = query.Where(p => p.BrandId == filter.BrandId);
                if (filter?.SectionId != null)
                    query = query.Where(p => p.SectionId == filter.SectionId);
            }
            
           
            
            return query;
        }


        public void Update(Product productNew)
        {
            var product = GetProductById(productNew.Id);
            product.Price = productNew.Price;
            product.Name = productNew.Name;
            product.Order = productNew.Order;
            product.ImageUrl = productNew.ImageUrl;
            product.SectionId = productNew.SectionId;
            product.BrandId = productNew.BrandId;
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetProductById(id);
            dbContext.Remove(product);
            dbContext.SaveChanges();
        }

        public Section GetSectionById(int id) =>
            dbContext.Sections.Include(s => s.Products).FirstOrDefault(s => s.Id == id);

        public Brand GetBrandById(int id) =>
            dbContext.Brands.Include(brand => brand.Products).FirstOrDefault(b => b.Id == id);

        public Product GetProductById(int id) => dbContext.Products
            .Include(p => p.Brand)
            .Include(p => p.Section)
            .FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }
    }
}

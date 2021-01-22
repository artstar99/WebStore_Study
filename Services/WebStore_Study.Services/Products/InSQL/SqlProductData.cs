using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Domain.Entities.Base;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Mapping;

namespace WebStore_Study.Services.Products.InSQL
{
    public class SqlProductData : IProductData
    {
        private readonly WebStore_StudyDb dbContext;

        public SqlProductData(WebStore_StudyDb dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<BrandDto> GetBrands() => dbContext.Brands
                .Include(b => b.Products)
                .AsEnumerable()
                .ToDto();

        public IEnumerable<SectionDto> GetSections() => dbContext.Sections.ToDto();

        public IEnumerable<ProductDto> GetProducts(ProductFilter filter = null)
        {
            IQueryable<Product> query = dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Section);

            if (filter?.Ids != null && filter?.Ids.Length > 0)
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



            return query.AsEnumerable().ToDto();
        }


        public void Update(ProductDto productNew)
        {
            var product = GetProductById(productNew.Id);
            product = productNew;
            dbContext.Entry(product).State = EntityState.Modified;
            //product.Price = productNew.Price;
            //product.Name = productNew.Name;
            //product.Order = productNew.Order;
            //product.ImageUrl = productNew.ImageUrl;
            //product.SectionId = productNew.SectionId;
            //product.BrandId = productNew.BrandId;
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetProductById(id);
            dbContext.Remove(product);
            dbContext.SaveChanges();
        }

        public SectionDto GetSectionById(int id) =>
            dbContext.Sections.Include(s => s.Products).FirstOrDefault(s => s.Id == id).ToDto();

        public BrandDto GetBrandById(int id) =>
            dbContext.Brands.Include(brand => brand.Products).FirstOrDefault(b => b.Id == id).ToDto();

        public ProductDto GetProductById(int id) => dbContext.Products
            .Include(p => p.Brand)
            .Include(p => p.Section)
            .FirstOrDefault(p => p.Id == id).ToDto();

        public void Add(ProductDto product)
        {
            dbContext.Products.Add(product.FromDto());
            dbContext.SaveChanges();
        }
    }
}

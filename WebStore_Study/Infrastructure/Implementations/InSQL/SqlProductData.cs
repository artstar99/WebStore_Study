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
        public IEnumerable<Brand> GetBrands() => dbContext.Brands;

        public IEnumerable<Section> GetSections() => dbContext.Sections;

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            IQueryable<Product> query = dbContext.Products;
            if (filter?.BrandId != null)
              query=query.Where(p => p.BrandId == filter.BrandId);
            if (filter?.SectionId != null)
                query = query.Where(p => p.SectionId == filter.SectionId);
            return query;
        }
    }
}

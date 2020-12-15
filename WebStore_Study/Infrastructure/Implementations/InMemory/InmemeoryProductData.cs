using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Data;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;

namespace WebStore_Study.Infrastructure.Implementations.InMemory
{
    public class InmemeoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            var query = TestData.Products;
            if (filter?.SectionId != null)
                query = query.Where(p => p.SectionId == filter.SectionId).ToList();

            if (filter?.BrandId != null)
                query = query.Where(p => p.BrandId == filter.BrandId).ToList();
            return query;
        }

        public IEnumerable<Section> GetSections() => TestData.Sections;
    }
}

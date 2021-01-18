using System;
using System.Collections.Generic;
using System.Linq;
using WebStore_Study.Data;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.Infrastructure.Implementations.InMemory
{
    [Obsolete("Класс устарел ибо устарел", true)]
    public class InmemeoryProductData : IProductData
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Brand GetBrandById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            var query = TestData.Products;
            if (filter?.SectionId != null)
                query = query.Where(p => p.SectionId == filter.SectionId).ToList();

            if (filter?.BrandId != null)
                query = query.Where(p => p.BrandId == filter.BrandId).ToList();
            return query;
        }

        public Section GetSectionById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Section> GetSections() => TestData.Sections;

        public void Update(Product productNew)
        {
            throw new NotImplementedException();
        }
    }
}

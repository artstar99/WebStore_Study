using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Data;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;

namespace WebStore_Study.Infrastructure.Implementations
{
    public class InmemeoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public IEnumerable<Section> GetSections() => TestData.Sections;
    }
}

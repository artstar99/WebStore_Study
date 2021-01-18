using System.Collections.Generic;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();
        IEnumerable<Brand> GetBrands();

        Section GetSectionById(int id);
        Brand GetBrandById(int id);
        IEnumerable<Product> GetProducts(ProductFilter filter=null);

        Product GetProductById(int id);

        void Update(Product productNew);
        void Delete(int id);

        void Add(Product product);

    }
}

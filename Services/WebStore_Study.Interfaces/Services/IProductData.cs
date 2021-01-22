using System.Collections.Generic;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<Domain.Dto.Products.SectionDto> GetSections();
        IEnumerable<Domain.Dto.Products.BrandDto> GetBrands();

        Domain.Dto.Products.SectionDto GetSectionById(int id);
        Domain.Dto.Products.BrandDto GetBrandById(int id);
        IEnumerable<ProductDto> GetProducts(ProductFilter filter=null);

        ProductDto GetProductById(int id);

        void Update(ProductDto productNew);
        void Delete(int id);

        void Add(ProductDto product);

    }
}

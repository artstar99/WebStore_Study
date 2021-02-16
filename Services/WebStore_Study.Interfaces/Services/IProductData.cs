using System.Collections.Generic;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<SectionDto> GetSections();
        IEnumerable<BrandDto> GetBrands();

        SectionDto GetSectionById(int id);
        BrandDto GetBrandById(int id);
        PageProductsDto GetProducts(ProductFilter filter=null);

        ProductDto GetProductById(int id);

        void Update(ProductDto productNew);
        void Delete(int id);

        void Add(ProductDto product);

    }
}

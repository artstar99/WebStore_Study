using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using WebStore_Study.Clients.Base;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Interfaces.Contracts;
using WebStore_Study.Interfaces.Services;


namespace WebStore_Study.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration configuration) : base(configuration, ApiRoutes.Version1.Products) { }

        public IEnumerable<SectionDto> GetSections() => Get<IEnumerable<SectionDto>>($"{Address}/sections");

        public SectionDto GetSectionById(int id) => Get<SectionDto>($"{Address}/sections/{id}");

        public IEnumerable<BrandDto> GetBrands() => Get<IEnumerable<BrandDto>>($"{Address}/brands");
        public BrandDto GetBrandById(int id) => Get<BrandDto>($"{Address}/brands/{id}");

        public IEnumerable<ProductDto> GetProducts(ProductFilter filter = null) =>
            Post(Address, filter ?? new ProductFilter())
                .Content.ReadAsAsync<IEnumerable<ProductDto>>()
                .Result;

        public ProductDto GetProductById(int id) => Get<ProductDto>($"{Address}/{id}");

        public void Add(ProductDto product) => Post($"{Address}/add", product);

        public void Delete(int id) => Delete($"{Address}/{id}");

        public void Update(ProductDto productNew) => Put($"{Address}", productNew);
    }
}
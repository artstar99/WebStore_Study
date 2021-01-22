using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebStore_Study.Clients.Base;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Contracts.V1;

namespace WebStore_Study.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration configuration) : base(configuration, ApiRoutes.Products) { }

        public IEnumerable<SectionDto> GetSections() => Get<IEnumerable<SectionDto>>($"{Address}/sections");

        public SectionDto GetSectionById(int id) => Get<SectionDto>($"{Address}/sections/{id}");


        public IEnumerable<BrandDto> GetBrands() => Get<IEnumerable<BrandDto>>($"{Address}/brands");
        public BrandDto GetBrandById(int id) => Get<BrandDto>($"{Address}/brands/{id}");


        public IEnumerable<ProductDto> GetProducts(ProductFilter filter = null) =>
            Post(Address, filter ?? new ProductFilter())
                .Content.
                ReadAsAsync<IEnumerable<ProductDto>>()
                .Result;
        public ProductDto GetProductById(int id) => Get<ProductDto>($"{Address}/products/{id}");



        public void Add(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(ProductDto productNew)
        {
            throw new NotImplementedException();
        }
    }
}

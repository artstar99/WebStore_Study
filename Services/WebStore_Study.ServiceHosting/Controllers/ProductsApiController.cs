using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Contracts.V1;

namespace WebStore_Study.ServiceHosting.Controllers
{
    [Route(ApiRoutes.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData productData;

        public ProductsApiController(IProductData productData)
        {
            this.productData = productData;
        }

        [HttpGet("sections")]
        public IEnumerable<SectionDto> GetSections() => productData.GetSections();

        [HttpGet("sections/{id}")]
        public SectionDto GetSectionById(int id) => productData.GetSectionById(id);
        
        
        [HttpGet("brands")]
        public IEnumerable<BrandDto> GetBrands() => productData.GetBrands();
        [HttpGet("brands/{id}")]
        public BrandDto GetBrandById(int id) => productData.GetBrandById(id);


        [HttpPost]
        public IEnumerable<ProductDto> GetProducts([FromBody] ProductFilter filter = null)
        {
            var products = productData.GetProducts(filter);
            return products;
        }

        [HttpGet("{id}")]
        public ProductDto GetProductById(int id) => productData.GetProductById(id);


        [HttpPost("add")]
        public void Add([FromBody] ProductDto product)
        {
            productData.Add(product);
        }


        [HttpPut]
        public void Update([FromBody]ProductDto productNew)
        {
            productData.Update(productNew);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productData.Delete(id);
        }
    }
}

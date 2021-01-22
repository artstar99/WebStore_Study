using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.ServiceHosting.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData productData;

        public ProductsApiController(IProductData productData)
        {
            this.productData = productData;
        }

        [HttpGet("sections")]
        public IEnumerable<Section> GetSections() => productData.GetSections();

        [HttpGet("sections/{id}")]
        public Section GetSectionById(int id) => productData.GetSectionById(id);
        
        
        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands() => productData.GetBrands();
        [HttpGet("brands/{id}")]
        public Brand GetBrandById(int id) => productData.GetBrandById(id);

       
        [HttpPost]
        public IEnumerable<Product> GetProducts([FromBody]ProductFilter filter = null) => productData.GetProducts(filter);
        [HttpGet("{id}")]
        public Product GetProductById(int id) => productData.GetProductById(id);


        [HttpPost]
        public void Add(Product product) => productData.Add(product);
        [HttpPut]
        public void Update(Product productNew) => productData.Update(productNew);
        [HttpDelete("{id}")]
        public void Delete(int id) => productData.Delete(id);








    }
}

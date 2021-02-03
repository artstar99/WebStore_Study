using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Interfaces.Contracts;
using WebStore_Study.Interfaces.Services;


namespace WebStore_Study.ServiceHosting.Controllers
{
    /// <summary>
    /// API управления товарами
    /// </summary>
    [Route(ApiRoutes.Version1.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData productData;
        public ProductsApiController(IProductData productData) => this.productData = productData;


        /// <summary>
        /// Получение всех секций
        /// </summary>
        /// <returns>Список секций магазина</returns>
        [HttpGet("sections")]
        public IEnumerable<SectionDto> GetSections() => productData.GetSections();

        /// <summary>
        /// Получение секции по id
        /// </summary>
        /// <param name="id">Идентификатор секции</param>
        [HttpGet("sections/{id}")]
        public SectionDto GetSectionById(int id) => productData.GetSectionById(id);
        
        /// <summary>
        /// Получение списка всех брендов
        /// </summary>
        /// <returns>Список брендов</returns>
        [HttpGet("brands")]
        public IEnumerable<BrandDto> GetBrands() => productData.GetBrands();
        
        /// <summary>
        /// Получение бренда по id
        /// </summary>
        /// <param name="id">Идентификатор бренда</param>
        [HttpGet("brands/{id}")]
        public BrandDto GetBrandById(int id) => productData.GetBrandById(id);

        /// <summary>
        /// Получение списка товаров по фильтру
        /// </summary>
        /// <param name="filter">Фильтр по секции/бренду/id-шникам</param>
        [HttpPost]
        public IEnumerable<ProductDto> GetProducts([FromBody] ProductFilter filter = null) => productData.GetProducts(filter);

        /// <summary>
        /// Получение товара по id
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        [HttpGet("{id}")]
        public ProductDto GetProductById(int id) => productData.GetProductById(id);

        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="product">Товар</param>
        [HttpPost("add")]
        public void Add([FromBody] ProductDto product) => productData.Add(product);

        /// <summary>
        /// Обновление существующего товара
        /// </summary>
        /// <param name="productNew">Экземпляр нового товар</param>
        [HttpPut]
        public void Update([FromBody] ProductDto productNew) => productData.Update(productNew);

        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="id">Идентификатор удаляемого товара</param>
        [HttpDelete("{id}")]
        public void Delete(int id) => productData.Delete(id);
    }
}

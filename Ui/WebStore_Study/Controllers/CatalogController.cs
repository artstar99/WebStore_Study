using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.Configuration;
using WebStore_Study.Domain;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Mapping;

namespace WebStore_Study.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData productData;
        private readonly IConfiguration configuration;

        public CatalogController(IProductData productData, IConfiguration configuration)
        {
            this.productData = productData;
            this.configuration = configuration;
        }

        public IActionResult Shop(int? brandId, int? sectionId, int page=1, int? pageSize=null)
        {
            var size = pageSize
                           ?? (int.TryParse(configuration["CatalogPageSize"], out var result) ? result : null);

            var filter = new ProductFilter
            {
                BrandId = brandId, SectionId = sectionId,
                Page = page,
                PageSize = size,
            };

            var pageProductsModel= productData.GetProducts(filter);
            
            return View(new CatalogViewModel
            {
                SectionId = sectionId,
                BrandId = brandId,
                Products = pageProductsModel.Products.FromDto()
                    .OrderBy(p => p.Order)
                    .ToView(),
                PageViewModel = new PageViewModel
                {
                    Page = page,
                    PageSize = size?? 0,
                    TotalItems = pageProductsModel.TotalCount,
                }
                
            });
        }

        public IActionResult Details(int id)
        {
            var product = productData.GetProductById(id).FromDto();
            if (product is null)
                return NotFound();
            return View(product.ToView());
        }
    }
}
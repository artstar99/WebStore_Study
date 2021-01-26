using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Mapping;


namespace WebStore_Study.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductData productData;

        public HomeController(IProductData productData)
        {
            this.productData = productData;
        }
        public IActionResult Index()
        {

            var products = productData
                .GetProducts()
                .OrderBy(p => p.Order)
                .Take(6)
                .ToList()
                .FromDto()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Order = p.Order,
                    Price = p.Price,
                });

            return View(products);
        }
    }
}

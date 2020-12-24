using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;

namespace WebStore_Study.Areas.Admin.Controllers
{
    [Area("Admin")][Authorize(Roles = Role.Administrator)]
    public class CatalogController : Controller
    {
        private readonly IProductData productData;

        public CatalogController(IProductData productData)
        {
            this.productData = productData;
        }
        public IActionResult Index()
        {
            var products = productData.GetProducts();
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            var product = productData.GetProductById(id);
            if (product is null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product productNew)
        {
            if (!ModelState.IsValid) return View(productNew);

            productData.Update(productNew);



            // редактирование
            // вызов метода из IProductData

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = productData.GetProductById(id);
            if (product is null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            productData.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

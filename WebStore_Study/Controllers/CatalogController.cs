﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore_Study.Domain;
using WebStore_Study.Infrastructure.Interfaces;
using WebStore_Study.Infrastructure.Mapping;
using WebStore_Study.ViewModels;

namespace WebStore_Study.Controllers
{

    public class CatalogController : Controller
    {
        private readonly IProductData productData;

        public CatalogController(IProductData productData)
        {
            this.productData = productData;
        }
        public IActionResult Shop(int? brandId, int? sectionId)
        {
            var filter = new ProductFilter { BrandId=brandId, SectionId=sectionId};
            var products = productData.GetProducts(filter);
            return View(new CatalogViewModel 
            {
                SectionId=sectionId,
                BrandId=brandId,
                Products= products
                .OrderBy(p=>p.Order)
                .ToView()
            } );
        }

        public IActionResult Details(int id)
        {
            var product = productData.GetProductById(id);
            if (product is null)
                return NotFound();
            
            
            
            return View(product.ToView());
        }
    }
}

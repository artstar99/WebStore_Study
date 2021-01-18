﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.Components
{
    public class BrandsViewComponent:ViewComponent
    {
        private readonly IProductData productData;
        public BrandsViewComponent(IProductData productData)
        {
            this.productData = productData;
        }
        public IViewComponentResult Invoke()
        {
            return View(GetBrands());
        }

        private IEnumerable<BrandViewModel> GetBrands() =>
            productData.GetBrands()
            .OrderBy(b => b.Order)
            .Select(b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Order = b.Order,
                ProductsCount=b.Products.Count(),
            });
        
    }
}

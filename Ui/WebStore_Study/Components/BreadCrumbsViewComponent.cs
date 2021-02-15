using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Mapping;
using WebStore_Study.ViewModels;

namespace WebStore_Study.Components
{
    public class BreadCrumbsViewComponent : ViewComponent
    {
        private readonly IProductData productData;

        public BreadCrumbsViewComponent(IProductData productData)
        {
            this.productData = productData;
        }

        public IViewComponentResult Invoke()
        {
            var model = new BreadCrumbsViewModel();

            if (int.TryParse(Request.Query["SectionId"], out var sectionId))
            {
                model.Section = productData.GetSectionById(sectionId).FromDto();
                if (model.Section.ParentId!=null)
                {
                    model.Section.Parent = productData.GetSectionById((int)model.Section.ParentId).FromDto();
                }
            }

            if (int.TryParse(Request.Query["BrandId"], out var brandId))
            {
                model.Brand = productData.GetBrandById(brandId).FromDto();
            }

            if (int.TryParse(ViewContext.RouteData.Values["id"]?.ToString(), out var productId))
            {
                var product= productData.GetProductById(productId);
                if (product!=null)
                {
                    model.Product = product.FromDto();
                }
            }
            

            return View(model);
        }




    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebStore_Study.Areas.Admin.ViewModels;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;

namespace WebStore_Study.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Role.Administrator)]
    public class CatalogController : Controller
    {
        private readonly IProductData productData;
        private readonly IWebHostEnvironment appEnvironment;

        public CatalogController(IProductData productData, IWebHostEnvironment appEnvironment)
        {
            this.productData = productData;
            this.appEnvironment = appEnvironment;
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

            var model = new ProductCreateViewModel()
            {
                Brands = productData.GetBrands(),
                Sections = productData.GetSections(),
                Product = product,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            //Меняем изоюражение
            if (model.Image != null)
            {
                string fileName = model.Image.FileName;
                string newImagepath = "/images/shop/" + fileName;

                //Удаляем старое изображение
                if (model.Product.ImageUrl!="noimage") 
                {
                    string oldImagePath = "/images/shop/" + model.Product.ImageUrl;
                    if (System.IO.File.Exists(appEnvironment.WebRootPath + oldImagePath))
                    {
                        try
                        {
                            System.IO.File.Delete(appEnvironment.WebRootPath + oldImagePath);
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                    }
                }

                model.Product.ImageUrl = fileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                await using var fileStream = new FileStream(appEnvironment.WebRootPath + newImagepath, FileMode.Create);
                await model.Image.CopyToAsync(fileStream);
            }
            var product = model.Product;
            productData.Update(product);
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

            var product = productData.GetProductById(id);
            if (product.ImageUrl != "noimage")
            {
                string fileName = product.ImageUrl;
                string path = "/images/shop/" + fileName;
                if (System.IO.File.Exists(appEnvironment.WebRootPath + path))
                {
                    try
                    {
                        System.IO.File.Delete(appEnvironment.WebRootPath + path);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }

            productData.Delete(id);
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Create()
        {
            var model = new ProductCreateViewModel
            {
                Brands = productData.GetBrands().ToList(),
                Sections = productData.GetSections().ToList(),
                Product = new Product { Order = 1, }
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EndCreate(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            model.Product.ImageUrl = "noimage.jpg";

            if (model.Image != null)
            {
                // путь к папке Files
                string fileName = model.Image.FileName;
                string path = "/images/shop/" + fileName;

                // сохраняем файл в папку Files в каталоге wwwroot
                model.Product.ImageUrl = fileName;
                await using var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create);
                await model.Image.CopyToAsync(fileStream);
            }
            productData.Add(model.Product);
            return RedirectToAction(nameof(Index));
        }
    }
}

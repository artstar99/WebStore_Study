using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebStore_Study.Controllers;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;
using Xunit;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace WebStore_Study.Tests.Controllers
{
    public class CatalogControllerTests
    {
        [Fact]
        public void DetailsReturnsCorrectView()
        {
            //arrange
           
            const int expectedProductId = 1;
            const decimal expectedPrice = 10m;
            var expectedProductName = "Mock Product-" + expectedProductId;
            var expectedBrandName = "Mock Brand For Product-" + expectedProductId;
            var expectedImageUrl = "Mock Image Url For Product-" + expectedProductId;
            var expectedSectionName = "Mock Section Name For Product-" + expectedProductId;

            var productDataMock = new Mock<IProductData>();
            productDataMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))
                .Returns<int>(id => new ProductDto(
                    id,
                    expectedProductName,
                    1,
                    expectedPrice,
                    expectedImageUrl,
                    new BrandDto(1, expectedBrandName, 1, 1),
                    new SectionDto(1, expectedSectionName, 1, null, 1)
                ));

            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(configuration => configuration[It.IsAny<string>()]).Returns("12");

            var controller = new CatalogController(productDataMock.Object, configurationMock.Object);
            
            //act

            var result = controller.Details(expectedProductId);


            //assert

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(viewResult.Model);

            Assert.Equal(expectedProductId, model.Id);
            Assert.Equal(expectedProductName, model.Name);
            Assert.Equal(expectedPrice, model.Price);
            Assert.Equal(expectedImageUrl, model.ImageUrl);
            Assert.Equal(expectedBrandName, model.Brand.Name);
            Assert.Equal(expectedProductName, model.Name);
        }

        [Fact]
        public void ShopReturnsCorrectView()
        {
            const int expectedSectionId = 1;
            const int expectedBrandId = 2;
            var products = new[]
            {
                new ProductDto(1, "Product-1", 1, 1m, "Image-1",
                    new BrandDto(1, "Brand-1", 1, 1),
                    new SectionDto(1, "Section-1", 1, null, null)),
                
                new ProductDto(2, "Product-2", 2, 2m, "Image-2",
                    new BrandDto(2, "Brand-21", 2, 2),
                    new SectionDto(2, "Section-2", 2, null, null)),
                
                new ProductDto(3, "Product-3", 3, 3m, "Image-3",
                    new BrandDto(3, "Brand-31", 3, 3),
                    new SectionDto(3, "Section-3", 3, null, null))
            };
            var productDataMock = new Mock<IProductData>(); 

            productDataMock
                .Setup(repo => repo.GetProducts(It.IsAny<ProductFilter>()))
                .Returns(products);

            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(configuration => configuration[It.IsAny<string>()]).Returns("12");

            var controller = new CatalogController(productDataMock.Object, configurationMock.Object);

            var result = controller.Shop(expectedBrandId, expectedSectionId);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<CatalogViewModel>(viewResult.Model);

            Assert.Equal(products.Length, model.Products.Count());
            Assert.Equal(expectedBrandId, model.BrandId);
            Assert.Equal(expectedSectionId, model.SectionId);
        }



    }
}

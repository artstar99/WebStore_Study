using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;
using Xunit;

namespace WebStore_Study.Services.Tests.Products
{
    public class CartServiceTests
    {
        private Cart cart;
        private Mock<IProductData> productDataMock;
        private ICartService cartService;
        public CartServiceTests()
        {
            cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new() {ProductId = 1, Quantity = 1},
                    new() {ProductId = 2, Quantity = 3},
                }
            };

            productDataMock = new Mock<IProductData>();
            productDataMock.Setup(c => c.GetProducts(It.IsAny<ProductFilter>()))
                .Returns(new List<ProductDto>
                {
                    new (1, "Product1", 1, 1.1m, "asd", new BrandDto(1, "Brand1", 1, 1), new SectionDto(1, "Section1", 1, null, 1)),
                    new (2, "Product2", 2, 2.2m, "fgh", new BrandDto(2, "Brand2", 2, 1), new SectionDto(2, "Section2", 2, null, 1))
                });
        }


        [Fact]
        public void CartClassItemsCountReturnsCorrectQuantity()
        {
            var cart = this.cart;
            const int expectedCount = 4;

            var actualCount = this.cart.ItemsCount;
            Assert.Equal(expectedCount, actualCount);

        }

        [Fact]
        public void CartViewModelReturnsCorrectItemsCount()
        {
            CartViewModel model = new()
            {
                Items = new[]
                {
                    (new ProductViewModel {Id = 1, Name = "Product1", Price = 0.5m, ImageUrl = "123"}, 1),
                    (new ProductViewModel {Id = 2, Name = "Product2", Price = 1.5m, ImageUrl = "asd"}, 3)
                }
            };

            const int expectedCount = 4;
            var actualCount = model.ItemsCount;
            Assert.Equal(expectedCount, actualCount);
        }

    }
}

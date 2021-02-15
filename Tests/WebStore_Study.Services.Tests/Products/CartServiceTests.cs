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
using WebStore_Study.Services.Products;
using Xunit;

namespace WebStore_Study.Services.Tests.Products
{
    public class CartServiceTests
    {
        private Cart cart;
        private Mock<IProductData> productDataMock;
        private Mock<ICartStore> cartStoreMock;
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
                .Returns(new PageProductsDto
                {
                    Products = new List<ProductDto>
                    {
                        new(1, "Product1", 1, 1.1m, "asd", new BrandDto(1, "Brand1", 1, 1),
                            new SectionDto(1, "Section1", 1, null, 1)),
                        new(2, "Product2", 2, 2.2m, "fgh", new BrandDto(2, "Brand2", 2, 1),
                            new SectionDto(2, "Section2", 2, null, 1))
                    },
                    TotalCount = 2,


                });

            cartStoreMock = new Mock<ICartStore>();
            cartStoreMock.Setup(c => c.Cart).Returns(cart);
            cartService = new CartService(productDataMock.Object, cartStoreMock.Object);

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

        [Fact]
        public void CartServiceAddToCartWorkCorrect()
        {
            cart.Items.Clear();
            const int expectedId = 5;
            const int expectedItemsCount = 1;

            cartService.AddToCart(expectedId);

            Assert.Equal(expectedItemsCount, cart.ItemsCount);

            Assert.Single(cart.Items);

            Assert.Equal(expectedId, cart.Items.First().ProductId);
        }

        [Fact]
        public void CartServiceRemoveFromCartCorrectItem()
        {
            const int itemId = 1;
            const int expectedProductId = 2;

            cartService.RemoveFromCart(itemId);

            cartService.RemoveFromCart(itemId);
            Assert.Single(cart.Items);
            Assert.Equal(expectedProductId, cart.Items.Single().ProductId);
        }

        [Fact]
        public void CartServiceClearWorksCorrect()
        {
            cartService.Clear();
            Assert.Empty(cart.Items);
        }

        [Fact]
        public void CartServiceDecrementWorksCorrect()
        {
            const int itemId = 2;
            const int expectedQuantity = 2;
            const int expectedItemsCount = 3;
            const int expectedProductsCount = 2;

            cartService.DecrementFromCart(itemId);

            Assert.Equal(expectedItemsCount, cart.ItemsCount);
            Assert.Equal(expectedProductsCount, cart.Items.Count);
            var items = cart.Items.ToArray();
            Assert.Equal(itemId, items[1].ProductId);
            Assert.Equal(expectedQuantity, items[1].Quantity);
        }

        [Fact]
        public void CartServiceRemoveItemWhenDecrementTo0()
        {
            const int itemId=1;
            const int expectedItemsCount = 3;

            cartService.DecrementFromCart(itemId);

            Assert.Equal(expectedItemsCount, cart.ItemsCount);
            Assert.Single(cart.Items);

        }
        
        [Fact]
        public void CartServiceTransformFromCartWorkCorrect()
        {
            const int expectedItemsCount = 4;
            const decimal expectedFirstProductPrice = 1.1m;

            var result = cartService.TransformFromCart();

            Assert.Equal(expectedItemsCount, result.ItemsCount);
            Assert.Equal(expectedFirstProductPrice, result.Items.First().product.Price);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Domain.ViewModels;
using Xunit;

namespace WebStore_Study.Services.Tests.Products
{
    public class CartServiceTests
    {
        private Cart cart;
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

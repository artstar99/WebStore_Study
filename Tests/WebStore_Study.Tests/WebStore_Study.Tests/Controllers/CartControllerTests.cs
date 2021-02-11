using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebStore_Study.Controllers;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Dto.Orders;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;
using Xunit;

namespace WebStore_Study.Tests.Controllers
{
    public class CartControllerTests
    {
        [Fact]
        public async Task CheckoutModelStateErrorReturnsViewWithModel()
        {
            var cartServiceMock = new Mock<ICartService>();
            var orderServiceMock = new Mock<IOrderService>();

            var controller = new CartController(cartServiceMock.Object);

            controller.ModelState.AddModelError("Test Error", "Test Error");

            const string expectedModelName = "Test order";
            var orderViewModel = new OrderViewModel {Name = expectedModelName}; 
            
            var result = await controller.CheckOut(orderViewModel, orderServiceMock.Object);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CartOrderViewModel>(viewResult.Model);
            
            Assert.Equal(expectedModelName, model.Order.Name);
        }

        [Fact]
        public async Task CheckoutReturnsRedirect()
        {
            var cartServiceMock = new Mock<ICartService>();

            cartServiceMock
                .Setup(repo => repo.TransformFromCart())
                .Returns(() => new CartViewModel
                {
                    Items = new[] {(new ProductViewModel { Name = "Product"} ,1)}
                });
            const int expectedOrderId = 1;

            var orderServiceMock = new Mock<IOrderService>();
            orderServiceMock
                .Setup(c => c.CreateOrder(It.IsAny<string>(), It.IsAny<CreateOrderModel>()))
                .ReturnsAsync(new OrderDto(
                    expectedOrderId,
                    "OrderName",
                    "Phone", 
                    "Address", 
                    DateTime.Now,
                    Enumerable.Empty<OrderItemDto>()));

            var controller = new CartController(cartServiceMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                            {new Claim(ClaimTypes.NameIdentifier, "TestUser")}))
                    }
                }
            };

            var orderModel = new OrderViewModel
            {
                Name = "TestOrder",
                Adress = "TestAddress",
                Phone = "0000000000",
            };

            var result = await controller.CheckOut(orderModel, orderServiceMock.Object);

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(CartController.OrderConfirmed), redirectResult.ActionName);
            Assert.Null(redirectResult.ControllerName);

            Assert.Equal(expectedOrderId, redirectResult.RouteValues["id"]);
        }
    }
}

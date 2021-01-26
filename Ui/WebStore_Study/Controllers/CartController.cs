using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebStore_Study.Domain.Dto.Orders;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
       
        public IActionResult Index()
        {
            return View(new CartOrderViewModel
            {
                Cart = cartService.TransformFromCart()
            }); // cartService.TransformFromCart());
        }

        public IActionResult AddToCart(int id)
        {
            cartService.AddToCart(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(int id)
        {
            cartService.RemoveFromCart(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DecrementFromCart(int id)
        {
            cartService.DecrementFromCart(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            cartService.Clear();
            return RedirectToAction(nameof(Index));
        }
        [Authorize][HttpPost]
        public async Task<IActionResult> CheckOut(OrderViewModel orderModel, [FromServices] IOrderService orderService)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), new CartOrderViewModel
                {
                    Cart = cartService.TransformFromCart(),
                    Order = orderModel
                });
                
            }

            var createOrderModel = new CreateOrderModel(
                orderModel,
                cartService
                    .TransformFromCart()
                    .Items
                    .Select(item => new OrderItemDto(item.product.Id, item.product.Price, item.quantity))
                    .ToList()
            );

            var order = await orderService.CreateOrder(User.Identity!.Name, createOrderModel);

            //var order = await orderService.CreateOrder(User.Identity!.Name, cartService.TransformFromCart(), orderModel);
            
            
            
            cartService.Clear();
            return RedirectToAction("OrderConfirmed", new {id=order.Id});
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

    }
}

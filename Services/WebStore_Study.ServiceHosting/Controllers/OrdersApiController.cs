using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore_Study.Domain.Dto.Orders;
using WebStore_Study.Interfaces.Contracts;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.ServiceHosting.Controllers
{
    [Route(ApiRoutes.Version1.Orders)]
    [ApiController]
    public class OrdersApiController : ControllerBase, IOrderService
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrdersApiController> logger;

        public OrdersApiController(IOrderService orderService, ILogger<OrdersApiController> logger)
        {
            this.orderService = orderService;
            this.logger = logger;
        }

        [HttpPost("{UserName}")]
        public async Task<OrderDto> CreateOrder(string userName, [FromBody] CreateOrderModel orderModel)
        {
            logger.LogInformation($"Формирование заказа для пользователя{userName}");
            var ord = await orderService.CreateOrder(userName, orderModel);
            return ord;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetOrderById(int id)
        {
            return await orderService.GetOrderById(id);
        }

        [HttpGet("user/{UserName}")]
        public async Task<IEnumerable<OrderDto>> GetUserOrders(string UserName)
        {
            return await orderService.GetUserOrders(UserName);
        }
    }
}
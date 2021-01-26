using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebStore_Study.Domain.Dto.Orders;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Contracts.V1;
using WebStore_Study.Domain.Entities.Orders;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.ServiceHosting.Controllers
{
    [Route(ApiRoutes.Orders)]
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

        [HttpPost]
        public async Task<OrderDto> CreateOrder(string userName, [FromBody]CreateOrderModel orderModel)
        {
            logger.LogInformation($"Формирование заказа для пользователя{userName}");
            var ord= await orderService.CreateOrder(userName, orderModel);
            return ord;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetOrderById(int id)
        {
            return await orderService.GetOrderById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetUserOrders(string UserName)
        {
            return await orderService.GetUserOrders(UserName);
        }
    }
}

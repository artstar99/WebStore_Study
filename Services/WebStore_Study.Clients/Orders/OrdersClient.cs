using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebStore_Study.Clients.Base;
using WebStore_Study.Domain.Dto.Orders;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Contracts.V1;

namespace WebStore_Study.Clients.Orders
{
    public class OrdersClient : BaseClient, IOrderService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<OrdersClient> logger;

        public OrdersClient(IConfiguration configuration, ILogger<OrdersClient> logger):base(configuration, ApiRoutes.Orders)
        {
            this.configuration = configuration;
            this.logger = logger;
        }
        public async Task<IEnumerable<OrderDto>> GetUserOrders(string UserName)
        {
            return await GetAsync<IEnumerable<OrderDto>>($"{Address}/user/{UserName}");
        }
        public async Task<OrderDto> GetOrderById(int id)
        {
            return await GetAsync<OrderDto>($"{Address}/{id}");
        }

        public async Task<OrderDto> CreateOrder(string userName, CreateOrderModel orderModel)
        {
            var response = await PostAsync($"{Address}/{userName}", orderModel);
            return await response.Content.ReadAsAsync<OrderDto>();
        }


    }
}

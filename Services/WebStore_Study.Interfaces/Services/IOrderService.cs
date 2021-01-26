using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore_Study.Domain.Dto.Orders;
using WebStore_Study.Domain.Entities.Orders;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Interfaces.Services
{
    public interface IOrderService
    {
       Task<IEnumerable<OrderDto>> GetUserOrders(string UserName);

        Task<OrderDto> GetOrderById(int id);
        Task<OrderDto> CreateOrder(string userName, CreateOrderModel orderModel);

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore_Study.Domain.Entities.Orders;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetUserOrders(string UserName);

        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(string userName, CartViewModel cart, OrderViewModel order);

    }
}

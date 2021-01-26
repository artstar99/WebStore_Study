using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Domain.Dto.Orders
{
    
        public record OrderItemDto (int Id, decimal Price, int Quantity);

        public record OrderDto(
            int Id,
            string Name,
            string Phone,
            string Address,
            DateTime Date,
            IEnumerable<OrderItemDto> Items);

        public record CreateOrderModel(OrderViewModel Order, IList<OrderItemDto> Items);
}

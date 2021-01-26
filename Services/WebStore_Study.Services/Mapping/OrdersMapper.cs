using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WebStore_Study.Domain.Dto.Orders;
using WebStore_Study.Domain.Entities.Orders;

namespace WebStore_Study.Services.Mapping
{
    public static class OrdersMapper
    {
        public static OrderItemDto ToDto(this OrderItem item) => item is null
            ? null
            : new OrderItemDto(
                item.Id,
                item.Price,
                item.Quantity);

        public static IEnumerable<OrderItemDto> ToDto(this IEnumerable<OrderItem> items) => items.Select(ToDto);

        public static OrderItem FromDto(this OrderItemDto itemDto) => itemDto is null
            ? null
            : new OrderItem
            {
                Id = itemDto.Id,
                Price = itemDto.Price,
                Quantity = itemDto.Quantity,
            };

        public static IEnumerable<OrderItem> FromDto(this IEnumerable<OrderItemDto> itemsDto) =>
            itemsDto.Select(FromDto);

        public static OrderDto ToDto(this Order order) => order is null
            ? null
            : new OrderDto(
                order.Id,
                order.Name,
                order.Phone,
                order.Adress,
                order.Date,
                order.Items.ToDto());

        public static IEnumerable<OrderDto> ToDto(this IEnumerable<Order> orders) => orders.Select(ToDto);

        public static Order FromDto(this OrderDto orderDto) => orderDto is null
            ? null
            : new Order
            {
                Id = orderDto.Id,
                Name = orderDto.Name,
                Adress = orderDto.Address,
                Date = orderDto.Date,
                Items = orderDto.Items.FromDto().ToList(),
                Phone = orderDto.Phone,
                
            };
    }
}

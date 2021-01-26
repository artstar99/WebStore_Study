using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain.Dto.Orders;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Domain.Entities.Orders;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Services.Mapping;

namespace WebStore_Study.Services.Products.InSQL
{
    public class SqlOrderService : IOrderService
    {
        private readonly WebStore_StudyDb context;
        private readonly UserManager<User> userManager;

        public SqlOrderService(WebStore_StudyDb context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<OrderDto> CreateOrder(string userName, CreateOrderModel orderModel)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
                throw new InvalidOperationException($"Пользователь {user} не найден в БД");
            
            await using var transaction = await context.Database.BeginTransactionAsync();

            
            var order = new Order()
            {
                Name = orderModel.Order.Name,
                Adress = orderModel.Order.Adress,
                Phone = orderModel.Order.Phone,
                User = user,
                Date = DateTime.Now,

            };
            foreach (var item in orderModel.Items)
            {
                var product = await context.Products.FindAsync(item.Id);
                if (product is null)
                    continue;
                var orderItem = new OrderItem
                {
                    Order = order,
                    Price = product.Price,
                    Quantity = item.Quantity,
                    Product = product
                };
                order.Items.Add(orderItem);
            };
            await context.AddAsync(order);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return order.ToDto();


        }
        public async Task<OrderDto> CreateOrder(string userName, CartViewModel cart, OrderViewModel orderModel)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
                throw new InvalidOperationException($"Пользователь {user} не найден в БД");

            await using var transaction = await context.Database.BeginTransactionAsync();

            var order = new Order()
            {
                Name = orderModel.Name,
                Adress = orderModel.Adress,
                Phone = orderModel.Phone,
                User = user,
                Date = DateTime.Now,

            };
            foreach (var (productModel, quantity) in cart.Items)
            {
                var product = await context.Products.FindAsync(productModel.Id);
                if (product is null)
                    continue;
                var orderItem = new OrderItem
                {
                    Order = order,
                    Price = product.Price,
                    Quantity = quantity,
                    Product = product
                };
                order.Items.Add(orderItem);
            };
            await context.AddAsync(order);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return order.ToDto();
        }

       

        public async Task<OrderDto> GetOrderById(int id)
        {
            var order = await context.Orders
                .Include(ord => ord.User)
                .Include(ord => ord.Items)
                .FirstOrDefaultAsync(ord => ord.Id == id);
            return order.ToDto();
        }

        public async Task<IEnumerable<OrderDto>> GetUserOrders(string userName)
        {
            var orders = await context.Orders
                 .Include(order => order.User)
                 .Include(order => order.Items)
                 .Where(order => order.User.UserName == userName).ToArrayAsync();
            return orders.ToDto();
        }
    }
}

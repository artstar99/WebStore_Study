using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebStore_Study.Infrastructure.Interfaces;
using WebStore_Study.ViewModels;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUsersData userDataService;

        public UserProfileController(IUsersData userDataService)
        {
            this.userDataService = userDataService;
        }
        public IActionResult Index()
        {
            
            var user = userDataService.GetById(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(new UsersViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age,
                Id = user.Id,

            });
        }

        
        public async Task<IActionResult> Orders([FromServices] IOrderService orderService)
        {
            var orders = await orderService.GetUserOrders(User.Identity!.Name);
            return View(orders.Select(order => new UserOrderViewModel
            {
                Id = order.Id,
                Address = order.Adress,
                Name = order.Name,
                TotalSum = order.Items.Sum(item => item.Price * item.Quantity)

            }));
        }



    }
}

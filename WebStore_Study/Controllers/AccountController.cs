using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebStore_Study.Domain.Entities;
using WebStore_Study.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebStore_Study.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager,
                                SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); ;
            }

            var user = new User
            {
                UserName=model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
               await signInManager.SignInAsync(user, isPersistent: false);
               return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError($"{error.Code}", error.Description);
                }
                
                return View(model);
            }
            

        }
    }
}

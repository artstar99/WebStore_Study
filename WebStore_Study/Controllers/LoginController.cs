﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebStore_Study.Domain.Entities;
using WebStore_Study.ViewModels;

namespace WebStore_Study.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public LoginController( UserManager<User> userManager,
                                SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var user = new User { };

            
            return RedirectToAction("Index", "Home");
        }
    }
}

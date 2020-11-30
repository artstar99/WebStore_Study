﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Models;

namespace WebStore_Study.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> employees = new List<Employee>()
        {
            new(){Id=1, LastName="Иванов", FirstName="Иван", Patronymic="Иванович", Age=31},
            new(){Id=1, LastName="Петров", FirstName="Пётр", Patronymic="Петрович", Age=32},
            new(){Id=1, LastName="Сидоров", FirstName="Сидор", Patronymic="Сидорович", Age=33},
            new(){Id=1, LastName="Константинов", FirstName="Константин", Patronymic="Константинович", Age=34}
        };
        public IActionResult Index()
        {
            //return Content("aslkdjas");
            return View();
        }
        public IActionResult SecondAction()
        {
            return Content("asdasd");
        }

        public IActionResult Employees()
        {
            return View(employees);
        }
    }
}

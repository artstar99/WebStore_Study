using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        readonly IUsersData UsersDataService;
        public UserController(IUsersData UsersDataService)
        {
            this.UsersDataService = UsersDataService;
        }
        public IActionResult Index()
        {
            var Users = UsersDataService.Load();
            List<UsersViewModel> viewModelList = new List<UsersViewModel>();
            foreach (var employee in Users)
            {
                viewModelList.Add(new UsersViewModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email=employee.Email,
                    Age = employee.Age,
                });
            }
            return View(viewModelList);
        }
        public IActionResult EmployeeDetail(string id)
        {
            var employee = UsersDataService.GetById(id);
            if (employee == null)
                return NotFound();


            return View(new UsersViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email=employee.Email,
                Age = employee.Age,
            });
        }
        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteEmployee(string id)
        {
            var employee = UsersDataService.GetById(id);
            if (employee == null)
                return NotFound();

            UsersViewModel UsersViewModel = new UsersViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Age = employee.Age,
            };
            return View(UsersViewModel);
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult EndDeleteEmployee(string id)
        {
            UsersDataService.Delete(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = Role.Administrator)]
        public IActionResult EditEmployee(string id)
        {
            if (id is null)
                return BadRequest();

            var employee = UsersDataService.GetById(id);

            if (employee is null)
                return NotFound();

            return View(new UsersViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Age = employee.Age,

            });
        }
        [Authorize(Roles = Role.Administrator)]
        public IActionResult EndEditEmployee(UsersViewModel UsersViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EditEmployee", UsersViewModel);
            }

            if (UsersViewModel is null)
                throw new ArgumentNullException(nameof(UsersViewModel));

            User employee = new User()
            {
                Id = UsersViewModel.Id,
                FirstName = UsersViewModel.FirstName,
                LastName = UsersViewModel.LastName,
                Email = UsersViewModel.Email,
                Age = UsersViewModel.Age,
            };
            UsersDataService.Update(employee);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = Role.Administrator)]
        public IActionResult AddEmployee()
        {
            return View(new UsersViewModel() {});
        }
        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult EndAddEmployee(UsersViewModel UsersViewModel)
        {
            if (!ModelState.IsValid)
                return View("AddEmployee", UsersViewModel);


            User employee = new User()
            {
                FirstName = UsersViewModel.FirstName,
                LastName = UsersViewModel.LastName,
                Email = UsersViewModel.Email,
                Age = UsersViewModel.Age,
            };

            UsersDataService.Add(employee);

            return RedirectToAction("Index");
        }

        

    }
}

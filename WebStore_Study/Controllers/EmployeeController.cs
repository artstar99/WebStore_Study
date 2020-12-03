using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Data;
using WebStore_Study.Models;
using WebStore_Study.Infrastructure.Interfaces;
using WebStore_Study.ViewModels;

namespace WebStore_Study.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeesData employeesDataService;
        public EmployeeController(IEmployeesData employeesDataService)
        {
            this.employeesDataService = employeesDataService;
        }
        public IActionResult Index()
        {
            var employees = employeesDataService.Load();
            return View(employees);
        }
        public IActionResult EmployeeDetail(int id)
        {
            var employee = employeesDataService.GetById(id);
            if (employee == null)
                return NotFound();

            return View(employee); // View("Error404");
        }

        public IActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest();
            var employee = employeesDataService.GetById(id);
            if (employee == null)
                return NotFound();

            EmployeesViewModel employeesViewModel = new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
            };
            return View(employeesViewModel);
        }

        [HttpPost]
        public IActionResult EndDeleteEmployee(int id)
        {
            employeesDataService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditEmployee(int id)
        {
            if (id < 0)
                return BadRequest();

            var employee = employeesDataService.GetById(id);

            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,

            });
        }
        public IActionResult EndEditEmployee(EmployeesViewModel employeesViewModel)
        {
            if (employeesViewModel is null)
                throw new ArgumentNullException(nameof(employeesViewModel));

            Employee employee = new()
            {
                Id = employeesViewModel.Id,
                FirstName = employeesViewModel.FirstName,
                LastName = employeesViewModel.LastName,
                Patronymic = employeesViewModel.Patronymic,
                Age = employeesViewModel.Age,
            };
            employeesDataService.Update(employee);
            return RedirectToAction("Index");
        }

        public IActionResult AddEmployee()
        {
            return View(new EmployeesViewModel() { Id = 0 });
        }
        public IActionResult EndAddEmployee(EmployeesViewModel employeesViewModel)
        {
            Employee employee = new()
            {
                FirstName = employeesViewModel.FirstName,
                LastName = employeesViewModel.LastName,
                Patronymic = employeesViewModel.Patronymic,
                Age = employeesViewModel.Age,
            };

            employeesDataService.Add(employee);

            return RedirectToAction("Index");
        }

    }
}

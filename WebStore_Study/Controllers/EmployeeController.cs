using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Data;
using WebStore_Study.Models;

namespace WebStore_Study.Controllers
{
    public class EmployeeController : Controller
    {
        private List<Employee> employees;
        public EmployeeController()
        {
            employees = TestData.Employees;
        }
        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult EmployeeDetail(int id)
        {

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                return View("Error404");
            }
        }

        public IActionResult DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            employees.Remove(emp);
            return RedirectToAction("Index");
        }
        public IActionResult EditEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }
        public IActionResult EndEditEmployee(string id, string firstName, string lastName, string patronymic, string age)
        {
            if (Int32.TryParse(id, out int result) && Int32.TryParse(age, out int ageResult))
            {
                //TODO: Сделать нормальную валидацию
                var emp = employees.FirstOrDefault(e => e.Id == result);
                emp.FirstName = firstName;
                emp.LastName = lastName;
                emp.Patronymic = patronymic;
                emp.Age = ageResult;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error404");

        }
        public IActionResult AddEmployee()
        {
            var emp = new Employee();
            emp.Id = employees.Max(e => e.Id)+1;
            return View(emp);
        }
        public IActionResult EndAddEmployee(Employee emp)
        {
            employees.Add(emp);

            return RedirectToAction("Index");

        }

    }
}

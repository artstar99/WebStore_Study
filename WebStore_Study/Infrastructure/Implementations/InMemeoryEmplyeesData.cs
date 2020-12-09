using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Data;
using WebStore_Study.Infrastructure.Interfaces;
using WebStore_Study.Models;

namespace WebStore_Study.Infrastructure.Implementations
{
    public class InMemeoryEmplyeesData : IEmployeesData
    {
        private readonly List<Employee> employees = TestData.Employees;

        public IEnumerable<Employee> Load() => employees;
        public Employee GetById(int id) => employees.FirstOrDefault(e => e.Id == id);
        
        public int Add(Employee employee)
        {
            if (employee is null)
                return 0;

            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            return employee.Id;
        }
    
        public void Delete(int id)
        {
            var employee = GetById(id);
            employees.Remove(employee);
        }

        public int Update(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            if (employees.Contains(employee))
                return employee.Id;

            var item = GetById(employee.Id);
            if (item == null)
                return 0;


            
            item.FirstName = employee.FirstName;
            item.LastName = employee.LastName;
            item.Patronymic = employee.Patronymic;
            item.Age = employee.Age;
            return item.Id;
        }

    }
}

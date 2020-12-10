using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;

namespace WebStore_Study.Infrastructure.Implementations.InSQL
{
    public class SqlEmployeeData : IEmployeesData
    {
        private readonly WebStore_StudyDb dbContext;

        public SqlEmployeeData(WebStore_StudyDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Employee employee)
        {
            if (employee is null)
                return;

            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                dbContext.Database.CommitTransaction();
            }
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
                dbContext.Database.CommitTransaction();
            }
        }

        public Employee GetById(int id) => dbContext.Employees.FirstOrDefault(e => e.Id == id);

        public IEnumerable<Employee> Load()
        {
            return dbContext.Employees.ToList();
        }

        public int Update(Employee emp)
        {
            if (emp == null)
                throw new ArgumentNullException(nameof(emp));

            if (dbContext.Employees.Contains(emp))
                return emp.Id;

            var item = GetById(emp.Id);
            if (item == null)
                return 0;
            using (dbContext.Database.BeginTransaction())
            {
                item.FirstName = emp.FirstName;
                item.LastName = emp.LastName;
                item.Patronymic = emp.Patronymic;
                item.Age = emp.Age;

                dbContext.SaveChanges();
                dbContext.Database.CommitTransaction();
                return item.Id;
            }

        }
    }
}

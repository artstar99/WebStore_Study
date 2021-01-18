using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;

namespace WebStore_Study.Infrastructure.Implementations.InSQL
{
    public class SqlEmployeeData : IUsersData
    {
        private readonly WebStore_StudyDb dbContext;

        public SqlEmployeeData(WebStore_StudyDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User employee)
        {
            if (employee is null)
                return;

            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Users.Add(employee);
                dbContext.SaveChanges();
                dbContext.Database.CommitTransaction();
            }
        }

        public void Delete(string id)
        {
            var employee = GetById(id);
            using (dbContext.Database.BeginTransaction())
            {
                dbContext.Users.Remove(employee);
                dbContext.SaveChanges();
                dbContext.Database.CommitTransaction();
            }
        }

        public User GetById(string id) => dbContext.Users.FirstOrDefault(e => e.Id == id);

        public IEnumerable<User> Load()
        {
            return dbContext.Users.ToList();
        }

        public bool Update(User emp)
        {
            if (emp == null)
                throw new ArgumentNullException(nameof(emp));


            if (dbContext.Users.Contains(emp))
                return false;

            var item = GetById(emp.Id);
            if (item == null)
                return false;
            using (dbContext.Database.BeginTransaction())
            {
                item.FirstName = emp.FirstName;
                item.LastName = emp.LastName;
                item.Patronymic = emp.Patronymic;
                item.Age = emp.Age;

                dbContext.SaveChanges();
                dbContext.Database.CommitTransaction();
                return true;
            }

        }
    }
}

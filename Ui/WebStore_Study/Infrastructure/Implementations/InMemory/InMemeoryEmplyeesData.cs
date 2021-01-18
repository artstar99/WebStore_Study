using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Data;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;


//namespace WebStore_Study.Infrastructure.Implementations.InMemory
//{
//    public class InMemeoryEmplyeesData : IUsersData
//    {
//        private readonly List<User> Users = TestData.Users;

//        public IEnumerable<User> Load() => Users;
//        public User GetById(int id) => Users.FirstOrDefault(e => e.Id == id);

//        public void Add(User employee)
//        {
//            if (employee is null)
//                return;

//            employee.Id = Users.Max(e => e.Id) + 1;
//            Users.Add(employee);
//        }

//        public void Delete(int id)
//        {
//            var employee = GetById(id);
//            Users.Remove(employee);
//        }

//        public int Update(User employee)
//        {
//            if (employee is null)
//                throw new ArgumentNullException(nameof(employee));

//            if (Users.Contains(employee))
//                return employee.Id;

//            var item = GetById(employee.Id);
//            if (item == null)
//                return 0;



//            item.FirstName = employee.FirstName;
//            item.LastName = employee.LastName;
//            item.Patronymic = employee.Patronymic;
//            item.Age = employee.Age;
//            return item.Id;
//        }



//    }
//}

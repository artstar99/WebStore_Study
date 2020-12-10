using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Domain.Entities;


namespace WebStore_Study.Infrastructure.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> Load();
        Employee GetById(int id);
        void Add(Employee employee);
        int Update(Employee emp);
        void Delete(int id);

    }
}

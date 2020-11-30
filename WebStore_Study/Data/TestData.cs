using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Models;

namespace WebStore_Study.Data
{
    public static class TestData
    {
        public static List<Employee> Employees { get; } = new List<Employee>()
        {
            new(){Id=1, LastName="Иванов", FirstName="Иван", Patronymic="Иванович", Age=31},
            new(){Id=2, LastName="Петров", FirstName="Пётр", Patronymic="Петрович", Age=32},
            new(){Id=3, LastName="Сидоров", FirstName="Сидор", Patronymic="Сидорович", Age=33},
            new(){Id=4, LastName="Константинов", FirstName="Константин", Patronymic="Константинович", Age=34}
        };
    }
}

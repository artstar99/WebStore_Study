using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Domain.Entities;


namespace WebStore_Study.Infrastructure.Interfaces
{
    public interface IUsersData
    {
        IEnumerable<User> Load();
        User GetById(string id);
        void Add(User employee);
        bool Update(User emp);
        void Delete(string id);

    }
}

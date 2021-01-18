using System.Collections.Generic;
using WebStore_Study.Domain.Entities;


namespace WebStore_Study.Interfaces.Services
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

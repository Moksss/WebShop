using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstractions.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        bool Insert(User user);
        bool Update(int userId, User user);
        bool Delete(int id);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);

    }
}

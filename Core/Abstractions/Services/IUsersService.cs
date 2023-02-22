using Core.Domain;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstractions.Services
{
    public interface IUsersService
    {
        List<UserViewModel> GetAll();
        UserViewModel GetById(int id);
        bool Insert(UserViewModel user);
        bool Update(int userId, UserViewModel user);
        bool Delete(int id);
        UserViewModel GetUserByUsername(string username);
        UserViewModel GetUserByEmail(string email);

    }
}

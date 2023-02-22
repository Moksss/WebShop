using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Core.Domain;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _repository;

        public UsersService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<UserViewModel> GetAll()
        {
            return _repository
                .GetAll()
                .Select<User?, UserViewModel?>(u => MapToViewModel(u))
                .ToList();
        }

        public UserViewModel GetById(int id)
        {
            return MapToViewModel(_repository.GetById(id));
        }

        public UserViewModel GetUserByEmail(string email)
        {
            return MapToViewModel(_repository.GetUserByEmail(email));
        }

        public UserViewModel GetUserByUsername(string username)
        {
            return MapToViewModel(_repository.GetUserByUsername(username));
        }

        public bool Insert(UserViewModel user)
        {
            return _repository.Insert(MapFromViewModel(user));
        }

        public bool Update(int userId, UserViewModel user)
        {
            return _repository.Update(userId, MapFromViewModel(user));
        }

        private UserViewModel? MapToViewModel(User? u)
        {
            if (u == null)
                return null;

            return new UserViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = String.Empty,
                UserName = u.UserName,
            };
        }

        private User? MapFromViewModel(UserViewModel? u)
        {
            if (u == null)
                return null;

            return new User
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = Encrypt(u.Password),
                UserName = u.UserName,
            };
        }
        private string Encrypt (string password)
        {
            return password;
        }
    }
}

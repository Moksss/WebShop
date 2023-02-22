using Core.Abstractions.Repositories;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string fileName = "WebShopUsers.json";

        private Dictionary<int, User> _users = new Dictionary<int, User>();
        private int _id = 0;

        public UserRepository()
        {
            LoadDatabase();
        }

        public bool Delete(int id)
        {
            if (_users.Remove(id))
            {
                SaveDatabase();
                return true;
            }

            return false;
        }

        public List<User> GetAll()
        {
            return _users.Values.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _users
                .Values
                .SingleOrDefault(u =>
                    u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public User GetById(int id)
        {
            if (_users.ContainsKey(id))
            {
                return _users[id];
            }

            return null;
        }

        public User GetUserByUsername(string username)
        {
            return _users
                .Values
                .SingleOrDefault(u =>
                    u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public bool Insert(User user)
        {
            if (GetUserByUsername(user.UserName) != null
                || GetUserByEmail(user.Email) != null)
            {
                return false;
            }

            user.Id = ++_id;
            _users.Add(user.Id, user);
            SaveDatabase();
            return true;
        }

        public bool Update(int userId, User user)
        {
            if (!_users.ContainsKey(userId))
            {
                return false;
            }

            var userByUsername = GetUserByUsername(user.UserName);
            if (userByUsername != null && userByUsername.Id != userId)
            {
                return false;
            }

            var userByEmail = GetUserByEmail(user.Email);
            if (userByEmail != null && userByEmail.Id != userId)
            {
                return false;
            }

            _users[userId] = user;
            SaveDatabase();

            return true;
        }

        private void LoadDatabase()
        {
            if (File.Exists(fileName))
            {
                try
                {
                    _users = JsonSerializer.Deserialize<Dictionary<int, User>>(
                        File.ReadAllText(fileName));
                }
                catch (Exception ex)
                {
                }
            }

            if (_users == null)
                _users = new Dictionary<int, User>();

            _id = _users.Count == 0
                ? 0
                : _users.Values.Select(p => p.Id).Max();
        }

        void SaveDatabase()
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(_users));
        }

    }
}


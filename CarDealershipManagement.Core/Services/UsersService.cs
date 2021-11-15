using CarDealershipManagement.Core.Interfaces;
using CarDealershipManagement.Core.Models;
using System;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    public class UsersService
    {
        private IRepository<User> _usersRepository;
        public UsersService(IRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public void AddUser(string login, string password)
        {
            CheckNewLoginAndPassword(login, password);
            _usersRepository.Insert(new User() { Login = login, Password = password });

        }

        private void CheckNewLoginAndPassword(string login, string password)
        {
            var users = _usersRepository.List().Select(u => u.Login == login);
            if (users.Any())
                throw new Exception();
        }
    }
}

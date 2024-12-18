using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionTracker.Abstraction;
using TransactionTracker.Model;
using TransactionTracker.Services.Interface;

namespace TransactionTracker.Services
{
    public class UserService: UserBase, IUserService
    {
        private List<Users> _users;

        public const string SeedUsername = "deepshikha";
        public const string SeedPassword = "password";
        public UserService()
        {
            _users = LoadUsers();

            if (!_users.Any())
            {
                _users.Add(new Users() { UserName = SeedUsername, Password = SeedPassword });
                SaveUsers(_users);
            }
        }
        public bool Login(string username, string password)
        {
            return _users.Any(u => u.UserName == username && u.Password == password);
        }
            
    }
}

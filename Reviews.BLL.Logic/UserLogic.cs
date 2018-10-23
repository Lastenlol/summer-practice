using BLL.Logging;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reviews.BLL.Interface;
using Reviews.DAL.Interface;

namespace Reviews.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;
        private readonly Logger _logger;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
            _logger = new Logger();
        }

        public bool AddUser(User user)
        {
            _userDao.AddUser(user);

            Logger.Log($"Added user {user.Id}");

            return true;
        }

        public bool DeleteUser(int id)
        {
            _userDao.DeleteUser(id);

            Logger.Log($"Deleted user {id}");

            return true;
        }

        public User GetUserById(int id)
        {
            Logger.Log($"Found user {id}");

            return _userDao.GetUserById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            Logger.Log($"Accessed users");

            return _userDao.GetUsers().ToList();
        }

        public bool UpdateUserForAdmin(int id, int role)
        {
            _userDao.UpdateUserForAdmin(id, role);

            Logger.Log($"Updated user role {id}");

            return true;
        }

        public bool UpdateUserForUsers(int id, string name)
        {
            _userDao.UpdateUserForUsers(id, name);

            Logger.Log($"Updated user data {id}");

            return true;
        }
    }
}

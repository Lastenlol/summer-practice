using System.Collections.Generic;
using Entity;

namespace Reviews.BLL.Interface
{
    public interface IUserLogic
    {
        bool AddUser(User user);
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        bool UpdateUserForAdmin(int id, int role);
        bool UpdateUserForUsers(int id, string name);
        bool DeleteUser(int id);
    }
}
using System.Collections.Generic;
using Entity;

namespace Reviews.DAL.Interface
{
    public interface IUserDao
    {
        int AddUser(User user);
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        int UpdateUserForUsers(int id, string name);
        int UpdateUserForAdmin(int id, int role);
        int DeleteUser(int id);
    }
}
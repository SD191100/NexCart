using Microsoft.EntityFrameworkCore;
using NexCart.Models;
namespace NexCart.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void AddUser(User user);
        void DeactivateUser(int id);
        void DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
    }
}



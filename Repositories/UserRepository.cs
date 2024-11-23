using Microsoft.EntityFrameworkCore;
using NexCart.Models;
namespace NexCart.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NexCartDBContext _context;

        public UserRepository(NexCartDBContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Email == username);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeactivateUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.IsActive = false;  // Assuming you have an IsActive field
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}


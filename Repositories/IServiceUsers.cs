using Microsoft.EntityFrameworkCore;
using NexCart.Models;
namespace NexCart.Repositories
{
    public interface IServiceUsers
    {
        public List<User> Get();
        public User GetById(int id);

        //public User Login(User user);

        public User Authenticate(string username, string password);

        //public ResponseModel SaveEmployee(Employee employee);
        //public ResponseModel DeleteEmployee(int id);
    }
}

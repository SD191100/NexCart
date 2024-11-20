using Microsoft.EntityFrameworkCore;
using NexCart.Models;
namespace NexCart.Repositories
{
    public class UsersRepository : IServiceUsers
    {
        
            private NexCartDBContext _Context;
            public UsersRepository(NexCartDBContext context)
            {
                _Context = context;
            }
            public List<User> Get()
            {
                List<User> empList;
                try
                {
                    empList = _Context.Set<User>().ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return empList;
            }
            public User GetById(int id)
            {
                User emp;
                try
                {
                    emp = _Context.Find<User>(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return emp;
            }

        //public User Login(User user) {
            
        //    return user;
        //}

        public User Authenticate ( string name, string password)
        {
            var user = _Context.Users.FirstOrDefault(u => u.Name == name && u.PasswordHash == password);
            return user;
        }

            
        }
    }


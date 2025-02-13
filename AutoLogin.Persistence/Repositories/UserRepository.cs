using AutoLogin.Domain.Entities;
using AutoLogin.Persistence.Context;
using AutoLogin.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLogin.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly LoginDbContext _context;
        public UserRepository(LoginDbContext context)
        {
            _context = context;
        }
        public User getByUserName(string userName)
        {
            return _context.Users.Where(u => u.UserName.Equals(userName)).FirstOrDefault();
        }

        public User saveUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex) {
                return user;            
            }
        }
    }
}

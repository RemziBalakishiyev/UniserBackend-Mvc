using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class UserRepository : IUser

    {
        private UniserContext _context;



        public UserRepository(UniserContext uniserContext)
        {
            _context = uniserContext;

        }

        public async Task CreateUser(User user)
        {
           

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByUser(string userName)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            if (user != null)
            {
                return user;
            }

            return null;
        }

     


       
    }
}

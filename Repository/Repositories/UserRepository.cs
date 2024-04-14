using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> GetByNamePassword(string user, string password)
        {
            var result = await _context.Users.Where(x => x.Password == password && x.UserName == user).FirstOrDefaultAsync();
            return result;
        }
    }
}

using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByNamePassword(string user, string password);
    }
}

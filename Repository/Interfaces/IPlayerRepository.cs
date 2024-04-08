using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<List<Player>> GetAll();
        Task<Player> GetId(int id);
        Task<Player> Insert(Player player);
        Task<Player> Update(Player player);
        Task<Player> Delete(int id);
        
    }
}

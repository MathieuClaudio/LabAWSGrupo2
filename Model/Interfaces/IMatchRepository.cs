using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IMatchRepository : IRepository<Match>
    {
        Task<List<Match>> GetAll();
        Task<Match> GetId(int id);
        Task<Match> Insert(Match club);
        Task<Match> Update(Match club);
        Task<Match> Delete(int id);
    }
}

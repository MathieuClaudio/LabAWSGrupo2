using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface ITournamentRepository : IRepository<Tournament>
    {
        Task<List<Tournament>> GetAll();
        Task<Tournament> GetId(int id);
        Task<Tournament> Insert(Tournament tournament);
        Task<Tournament> Update(Tournament tournament);
        Task<Tournament> Delete(int id);
        Task<string> GetTournamentNameById(int id);
    }
}

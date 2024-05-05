using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IMatchResultRepository : IRepository<MatchResult>
    {
        Task<List<MatchResult>> GetAll();
        Task<MatchResult> GetId(int id);
        Task<MatchResult> Insert(MatchResult matchResult);
        Task<MatchResult> Update(MatchResult matchResult);
        Task<MatchResult> Delete(int id);
        Task<MatchResult> GetMatchResult(int matchId);


    }
}

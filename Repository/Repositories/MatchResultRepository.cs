using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Entities;
using Model.Interfaces;

namespace Repository.Repositories
{
    public class MatchResultRepository : Repository<MatchResult>, IMatchResultRepository
    {
        public MatchResultRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<MatchResult>> GetAll()
        {
            var result = await _context.MatchResults.ToListAsync();
            return result;
        }

        public async Task<MatchResult> GetId(int id)
        {
            var result = await _context.MatchResults.FirstOrDefaultAsync(player => player.Id == id);
            return result;
        }

        public async Task<MatchResult> Insert(MatchResult match)
        {
            EntityEntry<MatchResult> insertPlayer = await _context.MatchResults.AddAsync(match);
            await _context.SaveChangesAsync();
            return insertPlayer.Entity;
        }

        public async Task<MatchResult> Update(MatchResult player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<MatchResult> Delete(int id)
        {
            var matchResult = await _context.MatchResults.FindAsync(id);
            if (matchResult == null)
            {
                throw new InvalidOperationException("Match Result no encontrado.");
            }

            _context.MatchResults.Remove(matchResult);
            await _context.SaveChangesAsync();
            return matchResult;
        }

        public async Task<MatchResult> GetMatchResult(int matchId)
        {
            var match = await _context.Matches.FindAsync(matchId);
            if (match == null)
                throw new InvalidOperationException("Match no encontrado.");
            
            var matchResult = await _context.MatchResults.Where(mr => mr.MatchId == matchId).FirstOrDefaultAsync();

            return matchResult;

        }
    }
}

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace Repository.Repositories
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Match>> GetAll()
        {
            var result = await _context.Matches.ToListAsync();
            return result;
        }

        public async Task<Match> GetId(int id)
        {
            var result = await _context.Matches.FirstOrDefaultAsync(match => match.Id == id);
            return result;
        }

        public async Task<Match> Insert(Match match)
        {
            EntityEntry<Match> insertMatch = await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return insertMatch.Entity;
        }

        public async Task<Match> Update(Match match)
        {
            _context.Entry(match).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<Match> Delete(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                throw new InvalidOperationException("Match no encontrado.");
            }

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return match;

        }

    }
}

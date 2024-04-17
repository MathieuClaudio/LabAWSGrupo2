using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await Context.Set<Match>().Include(m => m.Club).ToListAsync();
        }

        public async Task<Match> GetByIdAsync(int id)
        {
            return await Context.Set<Match>().Include(m => m.Club).FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool Exists(int id)
        {
            return Context.Set<Match>().Any(e => e.Id == id);
        }
    {
    }
}

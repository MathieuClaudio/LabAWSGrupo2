using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace Repository.Repositories
{
    public class StandingRepository : Repository<Standing>, IStandingRepository
    {
        public StandingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Standing>> GetAll()
        {
            var result = await _context.Standings.ToListAsync();
            return result;
        }

        public async Task<Standing> GetId(int id)
        {
            var result = await _context.Standings.FirstOrDefaultAsync(standing => standing.Id == id);
            return result;
        }

        public async Task<Standing> Insert(Standing standing)
        {
            EntityEntry<Standing> insertStanding = await _context.Standings.AddAsync(standing);
            await _context.SaveChangesAsync();
            return insertStanding.Entity;
        }

        public async Task<Standing> Update(Standing standing)
        {
            _context.Entry(standing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return standing;
        }

        public async Task<Standing> Delete(int id)
        {
            var standing = await _context.Standings.FindAsync(id);
            if (standing == null)
            {
                throw new InvalidOperationException("Standing no encontrado.");
            }

            _context.Standings.Remove(standing);
            await _context.SaveChangesAsync();
            return standing;

        }

        

        

    }
}
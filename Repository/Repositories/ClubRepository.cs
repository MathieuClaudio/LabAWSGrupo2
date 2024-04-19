using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Entities;

namespace Repository.Repositories
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        public ClubRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Club>> GetAll()
        {
            var result = await _context.Clubs.ToListAsync();
            return result;
        }

        public async Task<Club> GetId(int id)
        {
            var result = await _context.Clubs.FirstOrDefaultAsync(club => club.Id == id);
            return result;
        }

        public async Task<Club> Insert(Club club)
        {
            EntityEntry<Club> insertClub = await _context.Clubs.AddAsync(club);
            await _context.SaveChangesAsync();
            return insertClub.Entity;
        }

        public async Task<Club> Update(Club club)
        {
            _context.Entry(club).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return club;
        }

        public async Task<Club> Delete(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                throw new InvalidOperationException("Club no encontrado.");
            }

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();
            return club;

        }

    }
}

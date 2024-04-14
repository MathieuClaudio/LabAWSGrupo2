using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StadiumRepository : Repository<Stadium>, IStadiumRepository
    {
        public StadiumRepository(ApplicationDbContext context) : base(context)
        { 
        }

        public async Task<List<Stadium>> GetAll()
        {
            var result = await _context.Stadiums.ToListAsync();
            return result;
        }

        public async Task<Stadium> GetId(int id)
        {
            var result = await _context.Stadiums.FirstOrDefaultAsync(stadium => stadium.Id == id);
            return result;
        }

        public async Task<Stadium> Insert(Stadium stadium)
        {
            EntityEntry<Stadium> insertPlayer = await _context.Stadiums.AddAsync(stadium);
            await _context.SaveChangesAsync();
            return insertPlayer.Entity;
        }

        public async Task<Stadium> Update(Stadium stadium)
        {
            _context.Entry(stadium).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return stadium;
        }

        public async Task<Stadium> Delete(int id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null)
            {
                throw new InvalidOperationException("Stadium no encontrado.");
            }

            _context.Stadiums.Remove(stadium);
            await _context.SaveChangesAsync();
            return stadium;

        }


    }
}

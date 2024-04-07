using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> GetPlayerByNameAsync(string name)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.FullName == name);
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }


        public async Task CreatePlayerAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Player>> GetAll()
        {
            var result = await _context.Players.ToListAsync();
            return result;
        }

        public async Task<Player> GetId(int id)
        {
            var result = await _context.Players.FirstOrDefaultAsync(player => player.Id == id);
            return result;
        }

        public async Task<Player> Insert(Player player)
        {
            EntityEntry<Player> insertPlayer = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return insertPlayer.Entity;
        }

        public async Task<Player> Update(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> Delete(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                throw new InvalidOperationException("Player no encontrado.");
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return player;

        }

    }
}
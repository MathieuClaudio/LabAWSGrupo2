using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Interfaces;
﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;



namespace Repository.Repositories
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        
        public ClubRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        //public bool ClubExists(int id)
        //{
        //    return _context.Clubs.Any(c => c.Id == id);
        //}

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


        //public bool CreateClub(Club newClub)
        //{
        //    _context.Add(newClub);
        //    return Save();
        //}

        //public ICollection<Club> GetClubs()
        //{
        //    return _context.Clubs.ToList();
        //}

        //public Club GetClub(int id)
        //{
        //    return _context.Clubs.Where(c => c.Id == id).FirstOrDefault();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        
    }
}

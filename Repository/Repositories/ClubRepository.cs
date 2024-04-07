using AutoMapper;
using Model.Entities;
using Repository.Interfaces;
﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Repository.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ClubExists(int id)
        {
            return _context.Clubs.Any(c => c.Id == id);
        }

        public ICollection<Club> GetAll()
        {
            return _context.Clubs.ToList();
        }

        public bool CreateClub(Club newClub)
        {
            _context.Add(newClub);
            return Save();
        }

        public ICollection<Club> GetClubs()
        {
            return _context.Clubs.ToList();
        }

        public Club GetClub(int id)
        {
            return _context.Clubs.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

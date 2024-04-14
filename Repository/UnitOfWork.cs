using Model.Entities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPlayerRepository PlayerRepository { get; }
        public IClubRepository ClubRepository { get; }
        public IStadiumRepository StadiumRepository { get; }
        public IUserRepository UserRepository { get; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, 
                            IPlayerRepository playerRepository, 
                            IClubRepository clubRepository,
                            IStadiumRepository stadiumRepository,
                            IUserRepository userRepository
            )
        {
            _context = context;
            PlayerRepository = playerRepository;
            ClubRepository = clubRepository;
            StadiumRepository = stadiumRepository;
            UserRepository = userRepository;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

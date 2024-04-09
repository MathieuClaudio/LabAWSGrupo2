using Repository.Interfaces;
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
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, IPlayerRepository playerRepository, IClubRepository clubRepository)
        {
            _context = context;
            PlayerRepository = playerRepository;
            ClubRepository = clubRepository;
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

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
        public IMatchRepository MatchRepository { get; }
        public IStandingRepository StandingRepository { get; }
        public ITournamentRepository TournamentRepository { get; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, 
                            IPlayerRepository playerRepository, 
                            IClubRepository clubRepository,
                            IStadiumRepository stadiumRepository,
                            IUserRepository userRepository,
                            IMatchRepository matchRepository,
                            IStandingRepository standingRepository,
                            ITournamentRepository tournamentRepository
            )
        {
            _context = context;
            PlayerRepository = playerRepository;
            ClubRepository = clubRepository;
            StadiumRepository = stadiumRepository;
            UserRepository = userRepository;
            MatchRepository = matchRepository;
            StandingRepository = standingRepository;
            TournamentRepository = tournamentRepository;
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

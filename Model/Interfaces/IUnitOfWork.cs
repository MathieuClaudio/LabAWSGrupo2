using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public interface IUnitOfWork : IDisposable
    {
        public IPlayerRepository PlayerRepository { get; }
        public IClubRepository ClubRepository { get; }
        public IStadiumRepository StadiumRepository { get; }
        public IUserRepository UserRepository { get; }
        public IMatchRepository MatchRepository { get; }
        public IStandingRepository StandingRepository { get; }

        Task<int> Save();
    }
}

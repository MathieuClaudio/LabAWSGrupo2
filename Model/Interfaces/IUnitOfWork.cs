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

        Task<int> Save();
    }
}

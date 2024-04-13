using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork
    {
        // Listar Repos que implementan IUnitOfWork
        public IClubRepository ClubRepository { get; }

        Task<int> Save();
    }
}

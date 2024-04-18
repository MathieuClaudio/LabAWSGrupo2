using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    internal interface IMatchRepository
    {
        Task<List<Match>> GetAllAsync();
        Task<Match> GetByIdAsync(int id);
    }
}

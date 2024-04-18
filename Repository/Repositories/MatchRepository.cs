using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Match>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Match> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

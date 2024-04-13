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
        // Listar repos
        public IClubRepository ClubRepository { get; }
        
        
        
        //...


        private readonly ApplicationDbContext _context;

        // Constructor: sumar repos como parámetros.
        public UnitOfWork(ApplicationDbContext context, IClubRepository clubRepository)
        {
            
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

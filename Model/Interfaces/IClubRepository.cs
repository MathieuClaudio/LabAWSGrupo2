using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Interfaces
{
    public interface IClubRepository
    {
        Task<List<Club>> GetAll();
        Task<Club> GetId(int id);
        Task<Club> Insert(Club club);
        Task<Club> Update(Club club);
        Task<Club> Delete(int id);

    }
}

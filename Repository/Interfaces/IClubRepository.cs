using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Repository.Interfaces
{
    public interface IClubRepository
    {
        ICollection<Club> GetAll();
        Club GetClub(int id);
        bool CreateClub(Club club);
        bool ClubExists(int id);

    }
}

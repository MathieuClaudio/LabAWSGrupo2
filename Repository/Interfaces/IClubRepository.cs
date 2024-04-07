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
        ICollection<Club> GetClubs();
        bool CreateClub(Club newClub);
        bool ClubExists(int id);

    }
}


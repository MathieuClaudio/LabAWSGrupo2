using Microsoft.AspNetCore.JsonPatch;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public abstract class IClubRepository
    {
        public abstract Task<List<Club>> GetAll();
        public abstract Task<Club> GetClubById(int id);
        public abstract Task<Club> GetClubByName(string name);
        public abstract Task<Club> InsertClub(Club club);
        public abstract Task UpdateClub(Club club);
        public abstract Task DeleteClub(int id);
        public abstract Task<Club> UpdateClubPatch(int id, JsonPatchDocument<Club> patchDoc);
    }
}

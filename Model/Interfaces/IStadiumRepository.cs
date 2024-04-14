using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public interface IStadiumRepository : IRepository<Stadium>
    {
        Task<List<Stadium>> GetAll();
        Task<Stadium> GetId(int id);
        Task<Stadium> Insert(Stadium stadium);
        Task<Stadium> Update(Stadium stadium);
        Task<Stadium> Delete(int id);
    }
}

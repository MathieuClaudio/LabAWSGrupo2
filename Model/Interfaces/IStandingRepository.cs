using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IStandingRepository : IRepository<Standing>
    {
        Task<List<Standing>> GetAll();
        Task<Standing> GetId(int id);
        Task<Standing> Insert(Standing standing);
        Task<Standing> Update(Standing standing);
        Task<Standing> Delete(int id);
    }
}

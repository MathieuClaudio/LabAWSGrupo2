using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetId(int id);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

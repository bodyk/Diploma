using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Verbarium.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        T Create(T item);
        void Update(T item);
        void Delete(int id);
        Task DeleteAsync(int id);
        IQueryable<T> Query { get; }
        IDbSet<T> Entities { get; }
    }
}

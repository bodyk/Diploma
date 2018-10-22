using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Verbarium.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        T Create(T item);
        void Update(T item);
        IQueryable<T> Query { get; }
        IDbSet<T> Entities { get; }
    }
}

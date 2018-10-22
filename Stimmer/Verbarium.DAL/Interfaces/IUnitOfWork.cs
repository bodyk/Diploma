using System;
using System.Threading.Tasks;

namespace Verbarium.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();

        void Save();
        
        IGenericRepository<T> GetRepository<T>() where T : class;
    }
}

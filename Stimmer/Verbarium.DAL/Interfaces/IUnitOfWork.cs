using System;
using System.Threading.Tasks;
using Verbarium.DAL.Context;

namespace Verbarium.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();

        void Save();
        
        IGenericRepository<T> GetRepository<T>() where T : class;

        void ExecuteDirectly(string query);

        VerbariumContext Context { get; set; }
    }
}

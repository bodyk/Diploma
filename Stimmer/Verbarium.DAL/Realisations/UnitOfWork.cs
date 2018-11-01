using System;
using System.Data.Entity.Validation;
using Verbarium.DAL.Context;
using Verbarium.DAL.Exceptions;
using Verbarium.DAL.Interfaces;

namespace Verbarium.DAL.Realisations
{
    public class UnitOfWork : IUnitOfWork
    {
        public VerbariumContext Context { get; set; }
        private readonly IRepositoryFactory _factory;

        public UnitOfWork(VerbariumContext context, IRepositoryFactory factory)
        {
            Context = context;
            _factory = factory;
        }

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                _disposed = true;
            }
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return _factory.CreateRepository<T>(Context);
        }

        public void ExecuteDirectly(string query)
        {
            Context.Database.ExecuteSqlCommand(query);
        }
    }
}

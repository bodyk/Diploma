using System;
using System.Data.Entity.Validation;
using Verbarium.DAL.Context;
using Verbarium.DAL.Exceptions;
using Verbarium.DAL.Interfaces;

namespace Verbarium.DAL.Realisations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VerbariumContext _context;
        private readonly IRepositoryFactory _factory;

        public UnitOfWork(VerbariumContext context, IRepositoryFactory factory)
        {
            _context = context;
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
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
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
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return _factory.CreateRepository<T>(_context);
        }

        public void ExecuteDirectly(string query)
        {
            _context.Database.ExecuteSqlCommand(query);
        }
    }
}

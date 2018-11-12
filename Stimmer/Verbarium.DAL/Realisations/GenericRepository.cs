using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Verbarium.DAL.Interfaces;

namespace Verbarium.DAL.Realisations
{
    public class GenericRepository<T> : IGenericRepository<T> 
        where T : class, IEntity
    {
        protected readonly DbContext _context;
        private IDbSet<T> _entities;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return Entities.SingleOrDefaultAsync(i => i.Id == id);
        }

        public virtual T Create(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return Entities.Add(item);
        }

        public void Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            
            Entities.AddOrUpdate(item);
        }

        public void Delete(int id)
        {
            var entity = GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Entities.Remove(entity.Result);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Entities.Remove(entity);
        }

        public IQueryable<T> Query => Entities;
    }
}

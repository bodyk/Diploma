using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbarium.DAL.Interfaces;

namespace Verbarium.DAL.Realisations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
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

            _context.Entry(item).State = EntityState.Modified;
        }

        public IQueryable<T> Query => Entities;
    }
}

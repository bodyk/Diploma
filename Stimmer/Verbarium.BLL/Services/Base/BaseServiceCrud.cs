using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verbarium.BLL.Interfaces;
using Verbarium.DAL.Interfaces;

namespace Verbarium.BLL.Services.Base
{
    public abstract class BaseServiceCrud<T, TDto> : IGenericService<TDto>
        where T : class, IEntity
        where TDto : class, IDtoEntity
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IGenericRepository<T> Repository;
        protected readonly string TableName;

        protected BaseServiceCrud(IUnitOfWork unitOfWork, string tableName)
        {
            UnitOfWork = unitOfWork;
            TableName = tableName;
            Repository = UnitOfWork.GetRepository<T>();
        }

        public int Count => Repository.Query.Count();

        public void ExecuteDirectly(string query)
        {
            UnitOfWork.ExecuteDirectly(query);
        }

        protected virtual TDto EagerGet(int id)
        {
            return GetById(id);
        }

        protected virtual async Task<TDto> EagerGetAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public abstract IEnumerable<TDto> ConvertToDtos(IEnumerable<T> entities);

        public abstract IEnumerable<T> ConvertToEntities(IEnumerable<TDto> dtos);

        public abstract TDto ConvertToDto(T entity);

        public abstract T ConvertToEntity(TDto dto);

        public TDto Create(TDto dto)
        {
            var entity = ConvertToEntity(dto);

            var res = Repository.Create(entity);

            UnitOfWork.Save();

            return EagerGet(res.Id);
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = ConvertToEntity(dto);

            var res = Repository.Create(entity);

            await UnitOfWork.SaveAsync();

            return await EagerGetAsync(res.Id);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
            UnitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
            await UnitOfWork.SaveAsync();
        }

        public IEnumerable<TDto> GetAll()
        {
            var entities = Repository.GetAllAsync();

            return ConvertToDtos(entities.Result);
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await Repository.GetAllAsync();

            return ConvertToDtos(entities);
        }

        public TDto GetById(int id)
        {
            var entity = Repository.GetByIdAsync(id).Result;
            if (entity == null)
            {
                return default(TDto);
            }

            var dto = ConvertToDto(entity);

            return dto;
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity == null)
            {
                return default(TDto);
            }

            var dto = ConvertToDto(entity);

            return dto;
        }

        public TDto Update(TDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var entity = ConvertToEntity(dto);
            Repository.Update(entity);
            UnitOfWork.Save();
            return EagerGet(dto.Id);
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var entity = ConvertToEntity(dto);
            Repository.Update(entity);
            await UnitOfWork.SaveAsync();
            return await EagerGetAsync(dto.Id);
        }
    }
}

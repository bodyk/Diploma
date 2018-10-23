using System.Collections.Generic;
using System.Threading.Tasks;

namespace Verbarium.BLL.Interfaces
{
    public interface IGenericService<TDto>
        where TDto : class
    {
        IEnumerable<TDto> GetAll();
        TDto GetById(int id);
        TDto Create(TDto dto);
        TDto Update(TDto dto);
        void Delete(int id);

        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TDto dto);
        Task DeleteAsync(int id);
        Task<TDto> UpdateAsync(TDto dto);

        int Count { get; }
    }
}

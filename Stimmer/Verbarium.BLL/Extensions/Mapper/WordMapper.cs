using System.Linq;
using Verbarium.BLL.DTOs;
using Verbarium.DAL.Models;

namespace Verbarium.BLL.Extensions.Mapper
{
    public static class WordMapper
    {
        public static WordDto ToDto(this Word entity)
        {
            return new WordDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreationTime = entity.CreationTime,
                Classifiers = entity.Classifiers?.Select(e => e.ToDto()).ToList(),
                Quotes = entity.Quotes?.Select(e => e.ToDto()).ToList()
            };
        }

        public static Word ToEntity(this WordDto dto)
        {
            return new Word
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                //Classifiers = dto.Classifiers?.Select(e => e.ToEntity()).ToList(),
                //Quotes = dto.Quotes?.Select(e => e.ToEntity()).ToList()
            };
        }
    }
}

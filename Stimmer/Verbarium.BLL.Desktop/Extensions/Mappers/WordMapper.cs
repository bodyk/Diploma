using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Extensions.Mapper;
using Verbarium.DAL.Models;

namespace Verbarium.BLL.Desktop.Extensions.Mappers
{
    public static class WordMapper
    {
        public static Word ToWord(this WordDto dto)
        {
            return new Word
            {
                Name = dto.Name,
                Id = dto.Id,
                Description = dto.Description,
                CreationTime = dto.CreationTime,
                
                Classifiers = dto.Classifiers.Select(w => w.ToClassifier()).ToList()
            };
        }

        public static WordDto ToDto(this Word entity)
        {
            return new WordDto
            {
                Name = entity.Name,
                Id = entity.Id,
                Description = entity.Description,
                CreationTime = entity.CreationTime,

                Classifiers = entity.Classifiers.Select(w => w.ToDto()).ToList()
            };
        }

        public static List<Word> ToWordList(this List<WordDto> dtos)
        {
            return dtos.Select(w => w.ToWord()).ToList();
        }

        public static List<WordDto> ToWordDtoList(this List<Word> entities)
        {
            return entities.Select(w => w.ToDto()).ToList();
        }
    }
}

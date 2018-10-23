using System.Collections.Generic;
using System.Linq;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Extensions.Mapper;
using Verbarium.BLL.Interfaces;
using Verbarium.BLL.Services.Base;
using Verbarium.DAL.Interfaces;
using Verbarium.DAL.Models;

namespace Verbarium.BLL.Services
{
    public class WordServiceCrud : BaseServiceCrud<Word, WordDto>, IWordServiceCrud
    {
        public WordServiceCrud(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override IEnumerable<WordDto> ConvertToDtos(IEnumerable<Word> entities)
        {
            return entities.Select(entity => entity.ToDto());
        }

        public override IEnumerable<Word> ConvertToEntities(IEnumerable<WordDto> dtos)
        {
            return dtos.Select(dto => dto.ToEntity());
        }

        public override WordDto ConvertToDto(Word entity)
        {
            return entity.ToDto();
        }

        public override Word ConvertToEntity(WordDto dto)
        {
            return dto.ToEntity();
        }
    }
}

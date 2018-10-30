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
    public class QuoteServiceCrud : BaseServiceCrud<Quote, QuoteDto>, IQuoteServiceCrud
    {
        public QuoteServiceCrud(IUnitOfWork unitOfWork) : base(unitOfWork, "Quotes")
        {
        }

        public override IEnumerable<QuoteDto> ConvertToDtos(IEnumerable<Quote> entities)
        {
            return entities.Select(entity => entity.ToDto());
        }

        public override IEnumerable<Quote> ConvertToEntities(IEnumerable<QuoteDto> dtos)
        {
            return dtos.Select(dto => dto.ToEntity());
        }

        public override QuoteDto ConvertToDto(Quote entity)
        {
            return entity.ToDto();
        }

        public override Quote ConvertToEntity(QuoteDto dto)
        {
            return dto.ToEntity();
        }
    }
}

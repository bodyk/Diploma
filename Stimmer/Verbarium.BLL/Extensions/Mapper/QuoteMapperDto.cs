using Verbarium.BLL.DTOs;
using Verbarium.DAL.Models;

namespace Verbarium.BLL.Extensions.Mapper
{
    public static class QuoteMapperDto
    {
        public static QuoteDto ToDto(this Quote entity)
        {
            return new QuoteDto
            {
                Id = entity.Id,
                Content = entity.Content,
                CurrentWord = entity.CurrentWord.ToDto(),
                Author = entity.Author
            };
        }

        public static Quote ToEntity(this QuoteDto dto)
        {
            return new Quote
            {
                Id = dto.Id,
                Content = dto.Content,
                CurrentWord = dto.CurrentWord.ToEntity(),
                Author = dto.Author
            };
        }
    }
}

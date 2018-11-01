using System.Collections.Generic;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.Desktop.Interfaces
{
    public interface IQuoteService : IQuoteServiceCrud
    {
        List<QuoteDto> GetAllQuotes(int wordId, int? classifierId);
        int GetCountWordQuotes(int wordId, int classifierId);
        bool DeleteQuote(int quoteId);
    }
}

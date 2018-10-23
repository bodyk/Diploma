using System.Collections.Generic;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.Desktop.Interfaces
{
    public interface IQuoteService : IQuoteServiceCrud
    {
        bool AddQuote(int wordId, int classifierId, string quote, string author = null);
        List<QuoteDto> GetAllQuotes(int wordId, int classifierId = -1);
        int GetCountWordQuotes(int wordId, int classifierId);
        bool DeleteQuote(int quoteId);
    }
}

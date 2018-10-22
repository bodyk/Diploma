using System.Collections.Generic;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.Services
{
    public class QuoteService : IQuoteService
    {
        public bool AddQuote(int wordId, int classifierId, string quote, string author = null)
        {
            throw new System.NotImplementedException();
        }

        public List<QuoteDto> GetAllQuotes(int wordId, int classifierId = -1)
        {
            throw new System.NotImplementedException();
        }

        public int GetCountWordQuotes(int wordId, int classifierId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteQuote(int quoteId)
        {
            throw new System.NotImplementedException();
        }
    }
}

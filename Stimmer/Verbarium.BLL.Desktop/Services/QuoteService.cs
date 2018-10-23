using System.Collections.Generic;
using Verbarium.BLL.Desktop.Interfaces;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Services;
using Verbarium.DAL.Interfaces;

namespace Verbarium.BLL.Desktop.Services
{
    public class QuoteService : QuoteServiceCrud, IQuoteService
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

        public QuoteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Ninject;
using Verbarium.BLL.Desktop.Interfaces;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Extensions.Mapper;
using Verbarium.BLL.Services;
using Verbarium.DAL.Infrastructure;
using Verbarium.DAL.Interfaces;

namespace Verbarium.BLL.Desktop.Services
{
    public class QuoteService : QuoteServiceCrud, IQuoteService
    {
        public List<QuoteDto> GetAllQuotes(int wordId, int? classifierId)
        {
            return Repository.Query
                .Where(q =>
                    q.CurrentWord.Id == wordId &&
                    q.CurrentWord.Classifiers.Any(cl => cl.Id == classifierId)
                ).ToList().Select(q => q.ToDto()).ToList();
        }

        public int GetCountWordQuotes(int wordId, int classifierId)
        {
            return Repository.Query
                .Count(q => 
                        q.CurrentWord.Id == wordId && 
                        q.CurrentWord.Classifiers.Any(cl => cl.Id == classifierId)
                );
        }

        public bool DeleteQuote(int quoteId)
        {
            Delete(quoteId);
            return true;
        }

        public QuoteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public QuoteService() : base(new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>())
        {
            
        }
    }
}

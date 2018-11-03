using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ninject;
using Verbarium.BLL.Desktop.Extensions.Mappers;
using Verbarium.BLL.Desktop.Interfaces;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Services;
using Verbarium.DAL.Infrastructure;
using Verbarium.DAL.Interfaces;
using Verbarium.DAL.Models;

namespace Verbarium.BLL.Desktop.Services
{
    public class WordService : WordServiceCrud, IWordService
    {
        private int _maxCountLastWords = 30;

        public List<WordDto> FindWords(List<int> classifiersIds)
        {
            return UnitOfWork.Context.Classifiers.Where(cl => classifiersIds.Contains(cl.Id)).ToList()
                .SelectMany(cl => cl.Words.ToWordDtoList()).ToList();
        }

        public List<WordDto> GetLastWords()
        {
            return Repository.Entities
                .OrderByDescending(w => w.CreationTime)
                .Take(_maxCountLastWords)
                .ToList()
                .ToWordDtoList();
        }

        public WordDto GetWord(int wordId)
        {
            return GetById(wordId);
        }

        public List<WordDto> GetAllWords()
        {
            return GetAll().ToList();
        }

        public List<WordDto> GetWordStartsWith(string startPart)
        {
            return Repository.Entities.Where(w => w.Name.ToLower().StartsWith(startPart)).ToList().ToWordDtoList();
        }

        public void SetCountLastWords(int count)
        {
            _maxCountLastWords = count;
        }

        public int GetParentId(int classifierId)
        {
            throw new System.NotImplementedException();
        }

        public bool IsWordExists(string word)
        {
            return Repository.Query.Any(w => w.Name == word);
        }

        public bool AddWord(string sWord, List<ClassifierDto> parents, ref int wordId)
        {
            throw new System.NotImplementedException();
        }

        public bool AddQuote(int wordId, int classifierId, string quote, string author = null)
        {
            foreach (var word in Repository.Query.Where(w => w.Id == wordId && w.Classifiers.Any(cl => cl.Id == classifierId)).ToList())
            {
                word.Quotes.Add(new Quote
                {
                    Content = quote,
                    Author = author,
                    CurrentWord = word
                });
            }
            UnitOfWork.Save();
            return true;
        }

        public void AddLastWord(int wordId)
        {
        }

        public void ClearLastWords()
        {
            _maxCountLastWords = 0;
        }

        public bool UpdateWord(int wordId, string newWord)
        {
            Update(new WordDto
            {
                Id = wordId,
                Name = newWord
            });

            return true;
        }

        public bool DeleteWord(int wordId)
        {
            Delete(wordId);
            return true;
        }

        public void DeleteAllWords()
        {
            foreach (var entity in UnitOfWork.Context.Words)
                UnitOfWork.Context.Words.Remove(entity);
            UnitOfWork.Context.SaveChanges();
        }

        public WordService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public WordService() : base(new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>())
        {
            
        }
    }
}

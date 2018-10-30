using System.Collections.Generic;
using Ninject;
using Verbarium.BLL.Desktop.Interfaces;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Services;
using Verbarium.DAL.Infrastructure;
using Verbarium.DAL.Interfaces;

namespace Verbarium.BLL.Desktop.Services
{
    public class WordService : WordServiceCrud, IWordService
    {
        public List<WordDto> FindWords(List<int> classifiersIds, string searchCondition)
        {
            throw new System.NotImplementedException();
        }

        public List<WordDto> GetLastWords()
        {
            throw new System.NotImplementedException();
        }

        public WordDto GetWord(int wordId)
        {
            throw new System.NotImplementedException();
        }

        public List<WordDto> GetAllWords()
        {
            throw new System.NotImplementedException();
        }

        public List<WordDto> GetWordStartsWith(string startPart)
        {
            throw new System.NotImplementedException();
        }

        public List<ClassifierDto> GetWordClassifiers(int wordId, bool bMerge = true)
        {
            throw new System.NotImplementedException();
        }

        public List<ClassifierDto> GetWordParents(int wordId, bool isMerge = true)
        {
            throw new System.NotImplementedException();
        }

        public bool IsWordInClassifier(int wordId, int classifiersId)
        {
            throw new System.NotImplementedException();
        }

        public void SetCountLastWords(int count)
        {
            throw new System.NotImplementedException();
        }

        public int GetParentId(int classifierId)
        {
            throw new System.NotImplementedException();
        }

        public bool IsWordExists(string word)
        {
            throw new System.NotImplementedException();
        }

        public bool AddWord(string sWord, List<ClassifierDto> parents, ref int wordId)
        {
            throw new System.NotImplementedException();
        }

        public void AddLastWord(int wordId)
        {
            throw new System.NotImplementedException();
        }

        public void ClearLastWords()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateWord(int wordId, string newWord)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteWord(int wordId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAllWords()
        {
            throw new System.NotImplementedException();
        }

        public WordService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public WordService() : base(new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>())
        {
            
        }
    }
}

using System.Collections.Generic;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.Services
{
    public class WordService : IWordService
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
    }
}

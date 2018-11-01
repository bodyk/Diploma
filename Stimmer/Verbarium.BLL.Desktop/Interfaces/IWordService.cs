using System.Collections.Generic;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.Desktop.Interfaces
{
    public interface IWordService : IWordServiceCrud
    {
        List<WordDto> FindWords(List<int> classifiersIds, string searchCondition);
        List<WordDto> GetLastWords();
        WordDto GetWord(int wordId);
        List<WordDto> GetAllWords();
        List<WordDto> GetWordStartsWith(string startPart);
        List<ClassifierDto> GetWordClassifiers(int wordId, bool isMerge = true);
        List<ClassifierDto> GetWordParents(int wordId, bool isMerge = true);
        void SetCountLastWords(int count);

        int GetParentId(int classifierId);
        bool IsWordExists(string word);
        bool AddWord(string word, List<ClassifierDto> parents, ref int wordId);
        bool AddQuote(int wordId, int classifierId, string quote, string author = null);
        void AddLastWord(int wordId);
        void ClearLastWords();
        bool UpdateWord(int wordId, string newWord);
        bool DeleteWord(int wordId);
        void DeleteAllWords();
    }
}

using System.Collections.Generic;
using Verbarium.BLL.DTOs;

namespace Verbarium.BLL.Interfaces
{
    public interface IWordService
    {
        List<WordDto> FindWords(List<int> classifiersIds, string searchCondition);
        List<WordDto> GetLastWords();
        WordDto GetWord(int wordId);
        List<WordDto> GetAllWords();
        List<WordDto> GetWordStartsWith(string startPart);
        List<ClassifierDto> GetWordClassifiers(int wordId, bool bMerge = true);

        int GetParentId(int classifierId);
        bool IsWordExists(string word);
        bool AddWord(string sWord, List<ClassifierDto> parents, ref int wordId);
        bool UpdateWord(int wordId, string newWord);
        bool DeleteWord(int wordId);
        void DeleteAllWords();
    }
}

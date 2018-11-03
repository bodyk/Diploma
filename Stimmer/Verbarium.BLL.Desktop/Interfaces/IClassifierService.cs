using System.Collections.Generic;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.Desktop.Interfaces
{
    public interface IClassifierService : IClassifierServiceCrud
    {
        List<ClassifierDto> GetAllClassifiers(int? rootId);
        List<ClassifierDto> GetRootClassifiers();
        int GetParentId(int classifId);

        bool AddClassifier(string name, int parentId, ref int classifierId, string description = "");
        bool AddWord(int wordId, List<ClassifierDto> classifiers);
        List<ClassifierDto> GetWordParents(int wordId, bool isMerge = true);
        bool IsWordInClassifier(int wordId, int classifiersId);

        bool DeleteWordFromClassifier(int wordId, int classifierId);
        bool DeleteWordFromClassifier(int wordId, ClassifierDto dto);
        bool NormalizeClassifiers();
        bool DeleteClassifier(int classifierId);
        void DeleteAllClassifiers();
    }
}

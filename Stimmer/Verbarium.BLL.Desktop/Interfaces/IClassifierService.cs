using System.Collections.Generic;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.Desktop.Interfaces
{
    public interface IClassifierService : IClassifierServiceCrud
    {
        List<ClassifierDto> GetAllClassifiers(int rootId = -1);
        List<ClassifierDto> GetRootClassifiers();
        List<WordDto> GetClassifStartsWith(string startPart);
        List<ClassifierDto> GetPathToClassifier(int parentId = -1);
        int GetParentId(int classifId);

        bool AddClassifier(string name, int parentId, ref int classifierId, string description = "");
        bool AddWord(int wordId, List<ClassifierDto> classifiers);

        bool DeleteWordFromClassifier(int wordId, int classifierId);
        bool DeleteWordFromClassifier(int wordId, ClassifierDto dto);
        bool NormalizeClassifiers();
        bool DeleteClassifier(int classifierId);
        void DeleteAllClassifiers();
    }
}

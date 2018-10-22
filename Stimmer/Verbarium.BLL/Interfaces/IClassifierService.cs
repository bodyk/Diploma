using System.Collections.Generic;
using Verbarium.BLL.DTOs;

namespace Verbarium.BLL.Interfaces
{
    public interface IClassifierService
    {
        List<ClassifierDto> GetAllClassifiers(int rootId = -1);
        List<ClassifierDto> GetRootClassifiers();

        bool AddClassifier(string name, int parentId, ref int classifierId, string description = "");
        bool AddWord(int wordId, List<ClassifierDto> classifiers);

        bool DeleteWordFromClassifier(int wordId, int classifierId);
        bool NormalizeClassifiers();
        bool DeleteClassifier(int classifierId);
        void DeleteAllClassifiers();
    }
}

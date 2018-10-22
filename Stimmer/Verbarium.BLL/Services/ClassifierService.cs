using System.Collections.Generic;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.Services
{
    public class ClassifierService : IClassifierService
    {
        public List<ClassifierDto> GetAllClassifiers(int rootId = -1)
        {
            throw new System.NotImplementedException();
        }

        public List<ClassifierDto> GetRootClassifiers()
        {
            throw new System.NotImplementedException();
        }

        public bool AddClassifier(string name, int parentId, ref int classifierId, string description = "")
        {
            throw new System.NotImplementedException();
        }

        public bool AddWord(int wordId, List<ClassifierDto> classifiers)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteWordFromClassifier(int wordId, int classifierId)
        {
            throw new System.NotImplementedException();
        }

        public bool NormalizeClassifiers()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteClassifier(int classifierId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAllClassifiers()
        {
            throw new System.NotImplementedException();
        }
    }
}
